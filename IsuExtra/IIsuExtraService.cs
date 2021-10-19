using System.Collections.Generic;
using System.Collections.ObjectModel;
using Isu.Services.Students;

namespace IsuExtra
{
    public interface IIsuExtraService
    {
        void AddStudentToGroup(StudyGroup group, AdvancedStudent student);
        void EnrollStudentToOgnp(Ognp ognp, AdvancedStudent student);
        Ognp AddNewOgnp(string faculty, string name);
        List<Student> GetStudentsWithoutOgnp(StudyGroup group);
        ReadOnlyCollection<Stream> GetOgnpStreams(Ognp ognp);
        void DeleteStudentFromOgnp(Ognp ognp, AdvancedStudent student);
    }
}