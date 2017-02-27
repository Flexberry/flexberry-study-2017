using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Objects;
using CostCalculator;

namespace Task1.DAL
{
    public static class DataService 
    {
        public static double campus_cost = 500;
        private static List<Group> groups = new List<Group>()
            {
                new Group(GroupName.Group1, 1000),
                new Group(GroupName.Group2, 2000),
                new Group(GroupName.Group3, 3000),
                new Group(GroupName.Group4, 4000)
            };
        private static List<Student> students = new List<Student>();

        public static void AddStudent(Student student) 
        {
            CostCalc.Calc(student, campus_cost);
            students.Add(student);
        }

        public static void ClearStudents()
        {
            students.Clear();
        }

        public static void DeleteStudent(string name)
        {
            Student deleted = null;
            foreach (Student current in students)
                if (current.Name == name)
                    deleted = current;
            students.Remove(deleted);
        }

        public static List<Student> GetAllStudents()
        {
            return students;
        }

        public static List<Group> GetGroups()
        {
            return groups;
        }

        public static Student GetStudent(string name)
        {
            foreach (Student student in students)
                if (student.Name == name)
                    return student;
            throw new Exception("Нет такого студента");
        }

        public static List<Student> GetStudentsByGroup(GroupName groupName)
        {
            List<Student> result = new List<Student>();
            foreach (Student student in students)
                if (student.group.name == groupName)
                    result.Add(student);
            return result;
        }
    }
}
