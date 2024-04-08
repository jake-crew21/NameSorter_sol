namespace NameSorter
{
    //'Person' class to have the seperated first and last name of each element for sorting
    public class Person
    {
        public string FirstName;
        public string LastName;

        public bool FirstNameLimit(string firstName)
        {
            string[] givenNames = firstName.Split(' ');
            if (givenNames.Length <= 3) { return true; }
            else { return false; }
        }
    }
}
