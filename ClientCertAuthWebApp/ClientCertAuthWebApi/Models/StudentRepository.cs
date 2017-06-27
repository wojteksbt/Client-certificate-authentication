using System.Collections;
using System.Collections.Generic;

namespace ClientCertAuthWebApi.Models
{
    public class StudentRepository
    {
        private List<Student> _students = new List<Student>
        {
            new Student{Name = "Jan", Surname = "Kowalski", University = "Politechnika Krakowska", Group = "13k5", Grade = 4},
            new Student{Name = "Maciej", Surname = "Nowak", University = "Uniwersytet Jagielloński", Group = "12k8", Grade = 3},
            new Student{Name = "Zbigniew", Surname = "Zawisza", University = "Politechnika Krakowska", Group = "13k4", Grade = 2.5M},
            new Student{Name = "Wioletta", Surname = "Kwiecień", University = "Uniwersytet Jagielloński", Group = "13k2", Grade = 4.75M},
            new Student{Name = "Zygmunt", Surname = "Noszczyński", University = "Akademia Górniczo Hutnicza", Group = "11k1", Grade = 4},
            new Student{Name = "Monika", Surname = "Kubowicz", University = "Politechnika Krakowska", Group = "11k4", Grade = 3},
            new Student{Name = "Karolina", Surname = "Curuś", University = "Uniwersytet Jagielloński", Group = "13k5", Grade = 2},
            new Student{Name = "Marcin", Surname = "Miśkowiec", University = "Politechnika Krakowska", Group = "11k3", Grade = 3.5M},
            new Student{Name = "Abelard", Surname = "Stokłosa", University = "Akademia Górniczo Hutnicza", Group = "13k4", Grade = 4},
            new Student{Name = "Anastazja", Surname = "Kamiński", University = "Politechnika Krakowska", Group = "13k4", Grade = 4.98M},
            new Student{Name = "Jarosław", Surname = "Lem", University = "Politechnika Krakowska", Group = "12k5", Grade = 3},
            new Student{Name = "Eugeniusz", Surname = "Szymański", University = "Akademia Górniczo Hutnicza", Group = "13k1", Grade = 4.4M}
        };


        public IEnumerable<Student> GetAll()
        {
            return _students;
        }
    }
}