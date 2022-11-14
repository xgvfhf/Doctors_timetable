using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

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
                Enqueue(reader[1].ToString(), reader[2].ToString());//Filling values from patient list
            }
           // FillEmptySpaces();
            return FirstVisit;

             
        }

        public void FillEmptySpaces()
        {
            int Counter = 0;
            var temp = FirstVisit;
            while (temp.Next != null)
            {
                temp = temp.Next;
                Counter++;
            }
            for (int p = 0; p < 3 - Counter; p++)
            {
                for (int z = 0; z < 6 - temp.pt.Count; z++)
                {
                    string str;
                    if (z >= 0 && z <= 4)
                        str = "planned";
                    else
                        str = "unplanned";

                    temp.pt.Enqueue(new Patient { FirstName = "-", LastName = "-", TypeOfPatient = str, Date = dtm.ToShortTimeString(), Id = "-", Symptom = "-", Diagnosises = "-" });
                    dtm = dtm.AddMinutes(30);
                }
                temp.Next = new Interval();
                temp = temp.Next;
            }
            
        }

        public void Enqueue(string name,string surname)
        {
            
            string IdNum = "P" + new Random().Next(10000,99999).ToString(); // creating random ID,beginning with "P" and 5 digits after
            if (FirstVisit.pt.Count() < 4) // creating first node
            {
                FirstVisit.pt.Enqueue(new Patient { FirstName = name, LastName = surname, TypeOfPatient = "Planned" ,Date = dtm.ToShortTimeString(),Id = IdNum});
                dtm =  dtm.AddMinutes(30);
            }
           
            else // nodes after first one
            {
                var temp = FirstVisit;

                while (temp.pt.Count()==6 && temp.Next != null)
                {                   
                    temp = temp.Next;                   
                }

                if (temp.pt.Count() == 4)
                {
                    for (int i = 0; i < 2; i++)// filling the spaces for additional patients
                    {
                        dtm = dtm.AddMinutes(30);
                        temp.pt.Enqueue(new Patient { FirstName = "-", LastName = "-", TypeOfPatient = "Unplanned", Date = dtm.ToShortTimeString(),Id = "-" ,Symptom="-",Diagnosises="-"});             
                    }
                    temp.Next = new Interval();
                    dtm = dtm.AddMinutes(30);
                    temp.Next.pt.Enqueue(new Patient { FirstName = name, LastName = surname, TypeOfPatient = "Planned", Date = dtm.ToShortTimeString(), Id = IdNum , Symptom = "-", Diagnosises = "-" });
                    
                }
                else
                {
                    temp.pt.Enqueue(new Patient { FirstName = name, LastName = surname, TypeOfPatient = "Planned", Date = dtm.ToShortTimeString(), Id = IdNum, Symptom = "-", Diagnosises = "-" });
                    dtm = dtm.AddMinutes(30);
                }
                   

            }
            

        }
    }
}
