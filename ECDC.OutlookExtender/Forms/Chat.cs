using ECDC.OutlookExtender.Helpers;
using ECDC.Service.AI;
using Markdig;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Windows.Forms;
using static ECDC.Service.Files.ModelDataManager;

namespace ECDC.OutlookExtender.Forms
{
    public partial class Chat : Form
    {

        private readonly OpenAiService openAiService = null;
        private readonly ModelItem model;
        private readonly double temperature;
        private string conversation = string.Empty;


        public Chat(RibbonButton sender, RibbonDropDown dropdownTemperature, RibbonDropDown dropdownModel, string context)
        {

            InitializeComponent();


            try
            {
                sender.Enabled = false;

                temperature = ControlFlow.GetTemperatureFromDropDown(dropdownTemperature);
                model = ControlFlow.GetModelItemFromDropDown(dropdownModel);

                this.Text = this.Text + " - " + model.Name;

                var addIn = Globals.ThisAddIn;

                openAiService = new OpenAiService(model.ClientKey, model.UrlEndPoint, model.Name);

                if (string.IsNullOrEmpty(context)==false)
                    openAiService.AddContextToChat(context);

                TextBox_Input.KeyDown += TextBox_Input_KeyDown;

                WebBrowser_Conversation.DocumentCompleted += WebBrowser_Conversation_DocumentCompleted;

                TextBox_Context.Text = context;

            }
            finally
            {
                sender.Enabled = true;
            }
        }

        private void WebBrowser_Conversation_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var doc = WebBrowser_Conversation.Document;
            if (doc?.Body != null)
            {

                doc.Body.ScrollTop = doc.Body.ScrollRectangle.Height;

            }
        }

        private void TextBox_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the 'ding' sound in case the textbox is single-line
                e.SuppressKeyPress = true;

                // Perform your action here, e.g., simulate a button click:
                Button_Chat.PerformClick();
            }
        }

        private async void Button_Chat_Click(object sender, EventArgs e)
        {


            string question = TextBox_Input.Text;

            conversation += "ME: " + TextBox_Input.Text + Environment.NewLine + Environment.NewLine;
            SetHtml(conversation);

            TextBox_Input.Clear();
            
            var result = await openAiService.SendChatAsync(question, temperature, model.MaxTokens, model.TopP);

            conversation += "AI: " + result  + Environment.NewLine + Environment.NewLine;
            SetHtml(conversation);


        }

        private void SetHtml(string conversation)
        {

            string styledHtml = $@"
                <html>
                  <head>
                    <meta charset='utf-8' />                    
                    <style>
                        body {{font-family: Tahoma, sans-serif; font-size: 18px; line-height: 1.5; margin: 0; padding: 1em; }}
                        h1, h2, h3, h4, h5, h6 {{font-weight: bold; margin: 1em 0 0.5em 0; }}
                        p {{margin: 0 0 1em 0;}}
                        ul, ol {{margin: 0 0 1em 2em;}}
                        li {{margin: 0.5em 0;}}
                    </style>
                  </head>
                  <body>
                    {Markdown.ToHtml(conversation)}
                  </body>
                </html>";

            WebBrowser_Conversation.DocumentText = styledHtml;
        }

    }
}
