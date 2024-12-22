using System;
using System.Collections.Generic;
using System.Linq;

namespace JSGradesMini
{
    public static class QualificationTypeExtensions
    {
        public static List<string> Values => Enum.GetNames(typeof(QualificationType)).ToList();
    }

    public static class AssessmentTypeExtensions
    {
        public static List<string> Values => Enum.GetNames(typeof(AssessmentType)).ToList();
    }
}