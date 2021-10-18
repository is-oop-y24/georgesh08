using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IsuExtra
{
    public interface IIsuExtraService
    {
        void AddStudentToGroup(StudyGroup group, AdvancedStudent student);
        void EnrollStudentToOgnp(Ognp ognp, AdvancedStudent student);
        Ognp AddNewOgnp(string faculty, string name);
        List<AdvancedStudent> GetStudentsWithoutOgnp(StudyGroup group);
        ReadOnlyCollection<Stream> GetOgnpStreams(Ognp ognp);
        void DeleteStudentFromOgnp(Ognp ognp, AdvancedStudent student);
    }
}