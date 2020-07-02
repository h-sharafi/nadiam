namespace Domain
{
    public class PropertyTest
    {

        private string _MyProperty;
        public string MyProperty
        {
            get { return _MyProperty + " Mohammadi"; }
            set { _MyProperty = value; }
        }

    }
}