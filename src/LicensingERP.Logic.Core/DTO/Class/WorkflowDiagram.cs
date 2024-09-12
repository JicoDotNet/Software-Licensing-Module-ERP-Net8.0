namespace LicensingERP.Logic.DTO.Class
{
    public class node
    {
        public int key { get; set; }
        public string text { get; set; }
        public string color { get; set; } // { is Start: lightgreen, lightblue, is End: lightcoral }
        public string shape { get; set; } // { is Start: Circle, is End: RoundedRectangle }
    }

    public class link
    {
        public int from { get; set; }
        public int to { get; set; }
        public string text { get; set; }
        public string color { get; set; } // { approve: green, Rejected: red, RevertBack : blue }
    }

    public class WorkflowDiagram
    {
        public node[] nodes { get; set; }
        public link[] links { get; set; }
    }

    public enum eNodeColors
    {
        lightgreen,
        lightblue,
        lightcoral
    }

    public enum eLinkColors
    {
        green,
        red,
        blue
    }
}
