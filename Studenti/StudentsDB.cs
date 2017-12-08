using System;

namespace Studenti
{
    class StudentsDB
    {
        public Student[] ZoradenePole;

        private struct Student
        {
            public string meno, priezvisko;
            public int vek;
        }

        public void VytvorDatabazu()
        {
            string[] menaArr = new string[] { "Jakub", "Jan", "Tomas", "Peter", "Karol" };
            string[] priezviskaArr = new string[] { "Gejdos", "Rajcan", "Novak", "Jancovic", "Hudec" };
            Student[] studentiArr = new Student[10];
            Student[] studentiNewArr = new Student[10];
            Random r = new Random();
            bool sortBool;            

            for (int i = 0; i < 10; i++)
            {
                studentiArr[i].meno = menaArr[r.Next(5)];
                studentiArr[i].priezvisko = priezviskaArr[r.Next(5)];
                studentiArr[i].vek = r.Next(15, 81);
                //studentiArr[i].vek = i + 20; //testovanie zoradeneho pola
            }

            sortBool = ZoradStudentov(studentiArr, out studentiNewArr);
                
            Console.WriteLine("---------------------\nnezoradene pole\n---------------------");
            for (int i = 0; i < studentiArr.Length; i++)
            {
                Console.WriteLine("{0}. {1} {2}, {3} rokov", (i + 1), studentiArr[i].meno, studentiArr[i].priezvisko, studentiArr[i].vek);
            }

            Console.WriteLine("---------------------\nzoradene pole\n---------------------");
            for (int i = 0; i < studentiNewArr.Length; i++)
            {
                Console.WriteLine("{0}. {1} {2}, {3} rokov", (i + 1), studentiNewArr[i].meno, studentiNewArr[i].priezvisko, studentiNewArr[i].vek);
            }

            if (sortBool)
            {
                Console.WriteLine("\nPole bolo potrebne zoradit ({0})\n", sortBool);
            }
            else
            {
                Console.WriteLine("\nPole nebolo potrebne zoradit ({0})\n", sortBool);
            }
        }

        public bool ZoradStudentov(Student[] array, out Student[] newArray)
        {
            Student temp;
            newArray = (Student[]) array.Clone();

            //bubble sort
            bool triedenie = false;

            for (int write = 0; write < newArray.Length; write++)
            {
                for (int sort = 0; sort < newArray.Length - 1; sort++)
                {
                    if (newArray[sort].vek > newArray[sort + 1].vek)
                        
                    {
                        triedenie = true;
                        temp = newArray[sort + 1];
                        newArray[sort + 1] = newArray[sort];
                        newArray[sort] = temp;
                    }
                }
            }

            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i].vek != array[i].vek)
                {
                    return true;
                }               
            }

            return false;
        }
    }
}
