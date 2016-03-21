namespace Nexus.Client.ModManagement.Scripting.CSharpScript
{
    public struct SelectOption
    {
        public string Item;

        public string Preview;

        public string Desc;

        public SelectOption(string item, string preview, string desc)
        {
            Item = item;
            Preview = preview;
            Desc = desc;
        }
    }
}
