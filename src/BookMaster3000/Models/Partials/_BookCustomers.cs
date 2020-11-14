namespace BookMaster3000.Models
{
    public partial class BookCustomers
    {
        public string GetExportView(bool isReminders = true)
        {
            if (isReminders)
            {
                return $"\"{Books.Title}\"," +
                    $"\"{Customer.Name}\"," +
                    $"{IssueDate:dd.MM.yy}," +
                    $"{UntilDate:dd.MM.yy}";
            }
            return $"\"{Customer.Name}\"," +
                $"{IssueDate:dd.MM.yy}," +
                $"{UntilDate:dd.MM.yy}";
        }
    }
}
