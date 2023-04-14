using Bogus;

namespace GraphQL.API.Schema
{
    public class Query
    {
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<CourseType> _courseFaker;

        public Query()
        {
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(x => x.Id, y => Guid.NewGuid())
                .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                .RuleFor(x => x.LastName, y => y.Name.LastName())
                .RuleFor(x => x.Salary, y => y.Random.Double(0, 100000));

            _studentFaker = new Faker<StudentType>()
                .RuleFor(x => x.Id, y => Guid.NewGuid())
                .RuleFor(x => x.FirstName, y => y.Name.FirstName())
                .RuleFor(x => x.LastName, y => y.Name.LastName())
                .RuleFor(x => x.GPA, f => f.Random.Double(1, 4));

            _courseFaker = new Faker<CourseType>()
                .RuleFor(x => x.Id, y => Guid.NewGuid())
                .RuleFor(x => x.Name, y => y.Name.JobTitle())
                .RuleFor(x => x.Subject, y => y.PickRandom<Subject>())
                .RuleFor(x => x.Instructor, y => _instructorFaker.Generate())
                .RuleFor(x => x.Students, y => _studentFaker.Generate(3));
        }

        [GraphQLDeprecated("This query is deprecated")]
        public string Instructions => "Some Message";

        public IEnumerable<CourseType> GetCourses()
        {
            
            var courses = _courseFaker.Generate(5);
            return courses;
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(1000);
            CourseType course = _courseFaker.Generate();
            course.Id = id;
            return course;
        }
    }
}
