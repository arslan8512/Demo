﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace ConsoleApplication3
{
    class Student
    {
        private string id;
        private string name;
        private string semseter;
        private string cgpa;
        private string dept;
        private string uni;
        public void getData()
        {
            Console.WriteLine("Enter Student ID :");
            id = Console.ReadLine();
            Console.WriteLine("Enter Student name :");
            name = Console.ReadLine();
            Console.WriteLine("Enter Student Semester :");
            semseter = Console.ReadLine();
            Console.WriteLine("Enter Student CGPA :");
            cgpa = Console.ReadLine();
            Console.WriteLine("Enter Student Dept :");
            dept = Console.ReadLine();
            Console.WriteLine("Enter Student Uni :");
            uni = Console.ReadLine();
        }
        public void setData(string path)
        {
            FileStream Write_File = new FileStream(path, FileMode.Append);
            StreamWriter S_W = new StreamWriter(Write_File);
            S_W.WriteLine(id);
            S_W.WriteLine(name);
            S_W.WriteLine(semseter);
            S_W.WriteLine(cgpa);
            S_W.WriteLine(dept);
            S_W.WriteLine(uni);
            S_W.Close();
        }
    }
    class Program
    {
        void searchById(String path, String id)
        {
            FileStream Read_File = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader S_R = new StreamReader(Read_File);
            String line;
            while ((line = S_R.ReadLine()) != null)
            {
                if (line == id)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        System.Console.WriteLine(line);
                        line = S_R.ReadLine();
                    }
                }
            }
        }
        void searchByName(string path, string name)
        {
            Stack mystack = new Stack();
            FileStream Read_File = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader S_R = new StreamReader(Read_File);
            String line;
            while ((line = S_R.ReadLine()) != null)
            {
                if (line == name)
                {
                    System.Console.WriteLine(mystack.Pop());
                    for (int i = 0; i < 5; i++)
                    {
                        System.Console.WriteLine(line);
                        line = S_R.ReadLine();
                    }
                }
                mystack.Push(line);
            }
            S_R.Close();
        }
        void searchBySemester(String path, String semester)
        {
            Stack mystack = new Stack();
            FileStream Read_File = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader S_R = new StreamReader(Read_File);
            String line;
            while ((line = S_R.ReadLine()) != null)
            {
                if (line == semester)
                {
                    System.Console.WriteLine(mystack.Pop());
                    System.Console.WriteLine(mystack.Pop());
                    for (int i = 0; i < 4; i++)
                    {
                        System.Console.WriteLine(line);
                        line = S_R.ReadLine();
                    }
                }
                mystack.Push(line);
                line = S_R.ReadLine();
                mystack.Push(line);
            }
            
        }
        static void Main(string[] args)
        {
            String path = "D://xyz.txt";
            Program obj_pro = new Program();
            Console.Clear();
            Console.WriteLine("Press 1 FOR ENTERING STUDENTS PROFILE INFORMATION: ");
            Console.WriteLine("      2 FOR SEARCHING RECORD:  ");
            Console.WriteLine("      3 FOR DELETING A RECORD: ");
            Console.WriteLine("      4 FOR LISTING TOP 3 STUDENTS: ");
            Console.WriteLine("      5 FOR MARKING ATTENDANCE: ");
            Console.WriteLine("      6 FOR VIEWING ATTANDANCE: ");
            String choice = Console.ReadLine();
            if (choice == "1")
            {
                Student obj = new Student();
                obj.getData();
                obj.setData(path);
            }
            else if (choice == "2")
            {
                Console.Clear();
                Console.WriteLine("PRESS 1 TO SEARCH BY ID:   ");
                Console.WriteLine("      2 TO SEARCH BY NAME ");
                Console.WriteLine("      3 TO SEARCH BY SEMSTER");
                Console.WriteLine("Total Num of Students Are :");
                String searchchoice = Console.ReadLine();
                if (searchchoice == "1")
                {
                    Console.WriteLine("Enter ID :");
                    string id = Console.ReadLine();
                    obj_pro.searchById(path, id);
                }
                else if (searchchoice == "2")
                {
                    Console.WriteLine("Enter Name :");
                    string name = Console.ReadLine();
                    obj_pro.searchByName(path, name);
                }
                else if (searchchoice == "3")
                {
                    Console.WriteLine("Enter Semester :");
                    string semester = Console.ReadLine();
                    obj_pro.searchBySemester(path, semester);
                }
                else { Console.WriteLine("Invalid choice"); }
            }

        }
    }
}
