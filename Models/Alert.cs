namespace SharpCodeAssignmentOne.Models
{
    public class Alert
    {
        public string Success( string name, string action)
        {
            return "<div id = 'success' class='alert alert-success'><strong>Success! </strong> You have successfully " +action+ " <strong>"+ name +"</strong></div>";
        }
        public string Error()
        {
        return  "<div class='alert alert-danger'><strong>Danger!</strong> Indicates a dangerous or potentially negative action.</div>";
        }
    }
}
