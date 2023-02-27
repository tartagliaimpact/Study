namespace lab2_3
{
    //Интерфейс IStaff
    interface IStaff
    {
        List<JobVacancy> getJobVacancies();
        List<Employee> getEmployees();
        List<JobTitle> getJobTitles();
        int addJobTitle(JobTitle jobTitle);
        string printJobVacancies();
        bool delJobTitle(int indx);
        void openJobVacancy(JobVacancy jobVacancy);
        bool closeJobVacancy(int indx);
        Employee recruit(JobVacancy jobVacancy, Person person);
        bool dismiss(int indx, Reason reason);
    }



    //Класс Organization
    public class Organization : IStaff
    {
        //
        private int _id;
        public int id
        {
            get { return this._id; }
            private set { this._id = value; }
        }
        //
        private string? _name;
        public string? name
        {
            get { return this._name; }
            protected set { this._name = value; }
        }
        //
        private Type? _shortname;
        public Type? shortName
        {
            get { return this._shortname; }
            protected set { this._shortname = value; }
        }
        //
        private string? _address;
        public string? address
        {
            get { return this._address; }
            protected set { this._address = value; }
        }
        //
        private DateTime _timeStamp;
        public DateTime timeStamp
        {
            get { return this._timeStamp; }
            protected set { this._timeStamp = value; }
        }
        //
        public Organization()
        {
            this.id = 10;
            this.address = "Адресс";
            this.name = "Имя";
            this.shortName = this.GetType();
            this.timeStamp = DateTime.Now;
        }
        //
        public Organization(Organization org)
        {
            this.id = org.id;
            this.address = org.address;
            this.name = org.name;
            this.shortName = org.shortName;
            this.timeStamp = org.timeStamp;
        }
        //
        public Organization(string name, string shortName, string address)
        {
            this.id = 10;
            this.address = address;
            this.name = name;
            this.shortName = Type.GetType(shortName);
            this.timeStamp = DateTime.Now;
        }
        //
        public void printinfo()
        {
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Сокрощённое имя: {shortName}");
            Console.WriteLine($"Адрес: {address}");
            Console.WriteLine($"Дата основания: {timeStamp}");
        }
        //----
        protected List<Depatment> departments = new List<Depatment>();
        protected List<JobVacancy> jobvacancies = new List<JobVacancy>();
        protected List<JobTitle> jobtitles = new List<JobTitle>();
        protected List<Employee> employees = new List<Employee>();
        //
        public List<JobVacancy> getJobVacancies()
        {
            return jobvacancies;
        }
        //
        public List<Employee> getEmployees()
        {
            return employees;
        }
        //
        public List<JobTitle> getJobTitles()
        {
            return jobtitles;
        }
        //
        public int addJobTitle(JobTitle jobTitle)
        {
            try
            {
                jobtitles.Add(jobTitle);
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        //
        public string printJobVacancies()
        {
            foreach (JobVacancy item in jobvacancies)
            {
                Console.WriteLine(item);
            }
            return "-----";
        }
        //
        public bool delJobTitle(int indx)
        {
            try
            {
                jobtitles.RemoveAt(indx);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        public void openJobVacancy(JobVacancy jobVacancy)
        {
            try
            {
                jobvacancies.Add(jobVacancy);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        //
        public bool closeJobVacancy(int indx)
        {
            try
            {
                jobvacancies.RemoveAt(indx);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        public Employee recruit(JobVacancy jobVacancy, Person person)
        {
            foreach (JobVacancy item in jobvacancies)
            {
                if (person.job == jobVacancy)
                {
                    employees.Add(new Employee(person, jobVacancy));
                }
            }
            return new Employee(person, jobVacancy);
        }
        //
        public bool dismiss(int indx, Reason reason)
        {
            try
            {
                employees.RemoveAt(indx);
                Console.WriteLine(reason);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
    }

    //-----------------------------------------------------------
    //Класс Depatment
    public class Depatment
    {
        public string Name { get; set; }
        public Depatment()
        {
            this.Name = "Название";
        }
        public Depatment(string title)
        {
            this.Name = title;
        }

    }
    //Класс JobTitle
    public class JobTitle
    {

    }
    //Класс JobVacancy
    public class JobVacancy
    {
        public JobTitle job;
        public JobVacancy(JobTitle jobTitle)
        {
            this.job = jobTitle;
        }
    }
    //Класс Person
    public class Person
    {
        public string? name { get; set; }
        public int age { get; set; }
        public JobVacancy? job { get; set; }
        public Reason? reason { get; set; }
    }
    //Класс Reason
    public class Reason
    {
        public string? reason { get; set; }
    }
    //Класс Employee
    public class Employee
    {
        public Person candidate { get; set; }
        public JobVacancy job { get; set; }

        public Employee(Person person, JobVacancy jobVacancy)
        {
            this.job = jobVacancy;
            this.candidate = person;

        }
    }
    //-----------------------------------------------------------

    //Класс  Faculty
    public class Faculty : Organization, IStaff
    {
        //
        protected List<Depatment> departments = new List<Depatment>();
        protected List<JobVacancy> jobvacancies = new List<JobVacancy>();
        protected List<JobTitle> jobtitles = new List<JobTitle>();
        protected List<Employee> employees = new List<Employee>();
        //
        public Faculty()
        {
            this.address = "Адресс";
            this.name = "ИСиТ";
            this.shortName = this.GetType();
            this.timeStamp = DateTime.Now;
        }
        //
        public Faculty(Faculty faculty)
        {
            this.address = faculty.address;
            this.name = faculty.name;
            this.shortName = faculty.shortName;
            this.timeStamp = faculty.timeStamp;
        }
        //
        public Faculty(string name, string shortName, string address)
        {
            this.address = address;
            this.name = name;
            this.shortName = Type.GetType(shortName);
            this.timeStamp = DateTime.Now;
        }
        //
        public int addDepartment(Depatment depatment)
        {
            try
            {
                departments.Add(depatment);
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        //
        public bool delDepartment(int indx)
        {
            try
            {
                departments.RemoveAt(indx);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        public bool updDepartment(Depatment depatment)
        {
            try
            {
                if (addDepartment(depatment) == 1)
                {
                    Console.WriteLine("Обновлено. Добавлен новый элемент");
                }
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        private bool verDepartment(int cnt)
        {
            if (cnt == departments.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //
        public List<Depatment> getDepartments()
        {
            return departments;
        }
        //
        public void printinfo()
        {
            departments.ToString();
            Console.WriteLine("Департаменты:");
            foreach (Depatment item in departments)
            {
                Console.WriteLine(item.Name);

            }
        }
        //
        public List<JobVacancy> getJobVacancies()
        {
            return jobvacancies;
        }
        //
        public int addJobTitle(JobTitle jobTitle)
        {
            try
            {
                jobtitles.Add(jobTitle);
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        //
        public bool delJobTitle(int indx)
        {
            try
            {
                jobtitles.RemoveAt(indx);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        public int openJobVacancy(JobVacancy jobVacancy)
        {
            try
            {
                jobvacancies.Add(jobVacancy);
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        //
        public bool closeJobVacancy(int indx)
        {
            try
            {
                jobvacancies.RemoveAt(indx);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        public Employee recruit(JobVacancy jobVacancy, Person person)
        {
            foreach (JobVacancy item in jobvacancies)
            {
                if (person.job == jobVacancy)
                {
                    employees.Add(new Employee(person, jobVacancy));
                }
            }
            return new Employee(person, jobVacancy);
        }
        //
        public void dismiss(int num, Reason reason)
        {
            employees.RemoveAt(num);
            Console.WriteLine(reason);
        }



    }





    //Класс University
    public class University : Organization, IStaff
    {
        //
        protected List<Faculty> faculties = new List<Faculty>();
        protected List<JobVacancy> jobvacancies = new List<JobVacancy>();
        protected List<JobTitle> jobtitles = new List<JobTitle>();
        protected List<Employee> employees = new List<Employee>();
        //
        public University()
        {
            this.address = "Адресс";
            this.name = "БГТУ";
            this.shortName = this.GetType();
            this.timeStamp = DateTime.Now;
        }
        //
        public University(University university)
        {
            this.address = university.address;
            this.name = university.name;
            this.shortName = university.shortName;
            this.timeStamp = university.timeStamp;
        }
        //
        public University(string name, string shortName, string address)
        {
            this.address = address;
            this.name = name;
            this.shortName = Type.GetType(shortName);
            this.timeStamp = DateTime.Now;
        }
        //
        public int addFaculty(Faculty faculty)
        {
            try
            {
                faculties.Add(faculty);
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        //
        public bool delFaculty(int indx)
        {
            try
            {
                faculties.RemoveAt(indx);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        public bool updFaculty(Faculty faculty)
        {
            try
            {
                if (addFaculty(faculty) == 1)
                {
                    Console.WriteLine("Обновлено. Добавлен новый элемент");
                }
                return true;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        private bool verFaculty(int cnt)
        {
            if (cnt == faculties.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //
        public List<Faculty> getFaculties()
        {
            return faculties;
        }
        //
        public void printinfo()
        {
            faculties.ToString();
            Console.WriteLine("Факультеты:");
            foreach (Faculty item in faculties)
            {
                Console.WriteLine(item.name);
                Console.WriteLine(item.shortName);
                Console.WriteLine(item.address);

            }
        }
        //
        public List<JobVacancy> getJobVacancies()
        {
            return jobvacancies;
        }
        //
        public int addJobTitle(JobTitle jobTitle)
        {
            try
            {
                jobtitles.Add(jobTitle);
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        //
        public bool delJobTitle(int indx)
        {
            try
            {
                jobtitles.RemoveAt(indx);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        public int openJobVacancy(JobVacancy jobVacancy)
        {
            try
            {
                jobvacancies.Add(jobVacancy);
                return 1;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        //
        public bool closeJobVacancy(int indx)
        {
            try
            {
                jobvacancies.RemoveAt(indx);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //
        public Employee recruit(JobVacancy jobVacancy, Person person)
        {
            foreach (JobVacancy item in jobvacancies)
            {
                if (person.job == jobVacancy)
                {
                    employees.Add(new Employee(person, jobVacancy));
                }
            }
            return new Employee(person, jobVacancy);
        }
        //
        public void dismiss(int num, Reason reason)
        {
            employees.RemoveAt(num);
            Console.WriteLine(reason);
        }

    }




    class Program
    {
        static void Main()
        {
            JobTitle jobTitle = new JobTitle();
            JobVacancy jobVacancy = new JobVacancy(jobTitle);
            Person person = new Person();
            Reason reason = new Reason();
            Depatment depatment = new Depatment();
            Employee employee = new Employee(person, jobVacancy);
            Organization organization = new Organization();
            Organization organization1 = new Organization("Имя", "System.Int32", "Адресс");
            organization.printinfo();
            organization1.printinfo();
            University university = new University();
            Faculty faculty = new Faculty();
            (faculty as Organization).printinfo();
            (university as Organization).printinfo();
            faculty.addDepartment(depatment);
            faculty.printinfo();
            university.addFaculty(faculty);
            university.printinfo();
            organization.getJobVacancies();
            organization.getEmployees();
            organization.getJobTitles();
            organization.addJobTitle(jobTitle);
            Console.WriteLine(organization.printJobVacancies());
            organization.openJobVacancy(jobVacancy);
            organization.closeJobVacancy(0);
        }
    }



}