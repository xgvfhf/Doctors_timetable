using System;
using System.Data.OleDb;
using System.Linq;
namespace homework2
{
    public class Day
    {
        public Interval FirstVisit { get; set; }
        DateTime dtm = new DateTime(2022, 7, 20, 7, 0, 0);

        public Interval FillTheQueue()
        {
            var con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Проекти VS\homework2\homework2\PatientList.accdb");

            string query = "SELECT * FROM PatientList";
            con.Open();

            OleDbCommand command = new OleDbCommand(query, con);
            var reader = command.ExecuteReader();

            FirstVisit = new Interval();
            while (reader.Read())
            {
                AddPatient(reader[1].ToString(), reader[2].ToString());//Filling values from patient list
            }
            FillEmptySpaces();
            return FirstVisit;
        }

        public void FillEmptySpaces()
        {
            int CurrentQueueIndex = 0;// number of current queue
            int MaxNumOfQueue = 3;
            var temp = FirstVisit;

            while (temp.Next != null)//searching last queue which has values
            {
                temp = temp.Next;
                CurrentQueueIndex++;
            }
            int UnfilledQueuesNumber = MaxNumOfQueue - CurrentQueueIndex;//amount of unfilled queues
            
            
            for (int p = 0; p < UnfilledQueuesNumber; p++)// filling empty spaces
            {
                while (temp.pt.Count<6)
                {
                    string type;
                    if (temp.pt.Count >= 0 && temp.pt.Count < 4)
                        type = "planned";
                    else
                        type = "unplanned";

                    temp.pt.Enqueue(new Patient { FirstName = "-", LastName = "-", TypeOfPatient = type, Date = dtm.ToShortTimeString(), Id = "-", Symptom = "-", Diagnosises = "-" });
                    dtm = dtm.AddMinutes(30);
                }
                temp.Next = new Interval();
                temp = temp.Next;
            }
        }
        public string Rand()
        {
            return "P"+new Random().Next(10000, 99999).ToString();// creating random ID,beginning with "P" and 5 digits after
        }
        public void AddPatient(string name, string surname)
        {
            
            if (FirstVisit.pt.Count() < 4) // creating first node
            {

                FirstVisit.pt.Enqueue(new Patient { FirstName = name, LastName = surname, TypeOfPatient = "Planned", Date = dtm.ToShortTimeString(), Id = Rand(), Symptom = "-",Diagnosises = "-"});
                dtm = dtm.AddMinutes(30);
            }

            else // nodes after first one
            {
                var temp = FirstVisit;

                while (temp.pt.Count() == 6 && temp.Next != null)
                {
                    temp = temp.Next;
                }
                if (temp.pt.Count() == 4)
                {
                    for (int i = 0; i < 2; i++)// filling the spaces for additional patients
                    {
                        
                        temp.pt.Enqueue(new Patient { FirstName = "-", LastName = "-", TypeOfPatient = "Unplanned", Date = dtm.ToShortTimeString(), Id = "-", Symptom = "-", Diagnosises = "-" });
                        dtm = dtm.AddMinutes(30);
                    }
                    temp.Next = new Interval();
                    
                    temp.Next.pt.Enqueue(new Patient { FirstName = name, LastName = surname, TypeOfPatient = "Planned", Date = dtm.ToShortTimeString(),Id = Rand(),  Symptom = "-", Diagnosises = "-" });
                    dtm = dtm.AddMinutes(30);
                }
                else
                {
                    temp.pt.Enqueue(new Patient { FirstName = name, LastName = surname, TypeOfPatient = "Planned", Date = dtm.ToShortTimeString(), Id = Rand(), Symptom = "-", Diagnosises = "-" });
                    dtm = dtm.AddMinutes(30);
                }
            }
        }
    }
}
