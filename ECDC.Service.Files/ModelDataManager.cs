using System;
using System.Collections.Generic;
using static ECDC.Service.Files.ModelDataManager;

namespace ECDC.Service.Files
{
    public class ModelDataManager : DataManagerBase<List<ModelItem>>
    {

        public ModelDataManager() : base(
            "modeldata.json",
            AppDomain.CurrentDomain.BaseDirectory)
        {
        }

        public override void Save(List<ModelItem> data)
        {
            throw new NotImplementedException();
        }

        public class ModelItem
        {
            public string Name { get; set; }
            public string ClientKey { get; set; }
            public string UrlEndPoint { get; set; }
            public int MaxTokens { get; set; }
            public double TopP { get; set; }
            public override string ToString() {
                return $"max tokens: {MaxTokens}, top_p {TopP}";
            }
        }
    }
}
