﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenti
{
    
    public struct Student
    {
        public string meno, priezvisko;
        public int vek;
    }

    class StudentsDB
    {
        private string[] mena = new string[] { "Jakub", "Jan", "Tomas", "Peter", "Karol" };
        private string[] priezviska = new string[] { "Gejdos", "Rajcan", "Novak", "Jancovic", "Hudec" };
        private Student student = new Student();
        private Student[] studenti = new Student[10];

        public void VytvorDatabazu()
        {
            Student[] newArr = new Student[10];
            Random r = new Random();
            bool sortBool;
            
            for (int i = 0; i < 10; i++)
            {
                student.meno = mena[r.Next(5)];
                student.priezvisko = priezviska[r.Next(5)];
                student.vek = r.Next(15, 81);

                studenti[i] = student;
            }

            sortBool = ZoradStudentov(studenti, out newArr);

            if (sortBool)
            {
                Console.WriteLine("\nPole bolo potrebne zoradit ({0})\n", sortBool);
            }
            else
            {
                Console.WriteLine("\nPole nebolo potrebne zoradit ({0})\n", sortBool);
            }


            Console.WriteLine("---------------------\nnezoradene pole\n---------------------");
            foreach (Student st in studenti)
            {
                Console.WriteLine("{0} {1}, {2} rokov", st.meno, st.priezvisko, st.vek);
            }

            Console.WriteLine("---------------------\nzoradene pole\n---------------------");
            foreach (Student st in newArr)
            {
                Console.WriteLine("{0} {1}, {2} rokov", st.meno, st.priezvisko, st.vek);
            }
        }

        private bool ZoradStudentov(Student[] array, out Student[] newArray)
        {
            Student temp;
            newArray = (Student[]) array.Clone();

            for (int write = 0; write < newArray.Length; write++)
            {
                for (int sort = 0; sort < newArray.Length - 1; sort++)
                {
                    if (newArray[sort].vek > newArray[sort + 1].vek)
                    {
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
