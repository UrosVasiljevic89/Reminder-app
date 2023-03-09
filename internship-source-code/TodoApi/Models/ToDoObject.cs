namespace TodoApi.Models{
    public class ToDoObject
    {
        private string user;
        private bool check;
        private string title;
        private int id;
        public DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public void setTitle(string title){
            this.title = title;
        }
        
        public bool Check
        {
            get { return check; }
            set { check  = false; } //proveriti
        }
        public string User{
            get { return user; }
            set { user = value; }
        }
        
        public ToDoObject()
        {

        }
        public ToDoObject(string title, int id, DateTime date, bool check, string user)
        {
            this.title = title;
            this.check = check;
            this.id = id;
            this.date = date;
            this.user = user;
        }
        public ToDoObject(string title, int id, bool check, string user)
        {
            this.title = title;
            this.check = check;
            this.id = id;
            this.user = user;
        }

        

    }
}
