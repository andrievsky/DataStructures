using System.Collections.Generic;
using System.Linq;
using Assignments.Common;
using Assignments.Week3;
using Tests.Helpers;
using Xunit;

namespace Tests.Week3
{
    public class TestJobQueue
    {
        [Fact]
        public void TestExample1()
        {
            var input = new DataSource();
            input.AppendLine("2 5");
            input.AppendLine("1 2 3 4 5");
            var output = new DataSource();
            output.AppendLine("0 0");
            output.AppendLine("1 0");
            output.AppendLine("0 1");
            output.AppendLine("1 2");
            output.AppendLine("0 4");
            var assingment = new JobQueue();

            Assert.Equal(output.ToString(), assingment.Execute(input));
        }
        
        [Fact]
        public void TestExample2()
        {
            var input = new DataSource();
            input.AppendLine("4 20");
            input.AppendLine("1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1");
            var output = new DataSource();output.AppendLine("0 0");
            output.AppendLine("1 0");
            output.AppendLine("2 0");
            output.AppendLine("3 0");
            output.AppendLine("0 1");
            output.AppendLine("1 1");
            output.AppendLine("2 1");
            output.AppendLine("3 1");
            output.AppendLine("0 2");
            output.AppendLine("1 2");
            output.AppendLine("2 2");
            output.AppendLine("3 2");
            output.AppendLine("0 3");
            output.AppendLine("1 3");
            output.AppendLine("2 3");
            output.AppendLine("3 3");
            output.AppendLine("0 4");
            output.AppendLine("1 4");
            output.AppendLine("2 4");
            output.AppendLine("3 4");
   
            var assingment = new JobQueue();

            Assert.Equal(output.ToString(), assingment.Execute(input));
        }
        
        [Fact]
        public void TestDataSet2()
        {
            var input = new DataSource();
            input.AppendLine("10 100");
            var inputValues = "124860658 388437511 753484620 349021732 311346104 235543106 665655446 28787989 706718118 409836312 217716719 757274700 609723717 880970735 972393187 246159983 318988174 209495228 854708169 945600937 773832664 587887000 531713892 734781348 603087775 148283412 195634719 968633747 697254794 304163856 554172907 197744495 261204530 641309055 773073192 463418708 59676768 16042361 210106931 901997880 220470855 647104348 163515452 27308711 836338869 505101921 397086591 126041010 704685424 48832532 944295743 840261083 407178084 723373230 242749954 62738878 445028313 734727516 370425459 607137327 541789278 281002380 548695538 651178045 638430458 981678371 648753077 417312222 446493640 201544143 293197772 298610124 31821879 46071794 509690783 183827382 867731980 524516363 376504571 748818121 36366377 404131214 128632009 535716196 470711551 19833703 516847878 422344417 453049973 58419678 175133498 967886806 49897195 188342011 272087192 798530288 210486166 836411405 909200386 561566778";
            input.AppendLine(inputValues);
            var output = new DataSource();
            output.AppendLine("0 0");
            output.AppendLine("1 0");
            output.AppendLine("2 0");
            output.AppendLine("3 0");
            output.AppendLine("4 0");
            output.AppendLine("5 0");
            output.AppendLine("6 0");
            output.AppendLine("7 0");
            output.AppendLine("8 0");
            output.AppendLine("9 0");
            output.AppendLine("7 28787989");
            output.AppendLine("0 124860658");
            output.AppendLine("5 235543106");
            output.AppendLine("7 246504708");
            output.AppendLine("4 311346104");
            output.AppendLine("3 349021732");
            output.AppendLine("1 388437511");
            output.AppendLine("9 409836312");
            output.AppendLine("3 595181715");
            output.AppendLine("9 619331540");
            output.AppendLine("6 665655446");
            output.AppendLine("8 706718118");
            output.AppendLine("1 707425685");
            output.AppendLine("2 753484620");
            output.AppendLine("5 845266823");
            output.AppendLine("0 882135358");
            output.AppendLine("0 1030418770");
            output.AppendLine("7 1127475443");
            output.AppendLine("0 1226053489");
            output.AppendLine("1 1239139577");
            output.AppendLine("4 1283739291");
            output.AppendLine("8 1294605118");
            output.AppendLine("6 1439488110");
            output.AppendLine("5 1448354598");
            output.AppendLine("3 1449889884");
            output.AppendLine("2 1488265968");
            output.AppendLine("8 1492349613");
            output.AppendLine("1 1543303433");
            output.AppendLine("8 1552026381");
            output.AppendLine("1 1559345794");
            output.AppendLine("9 1564932477");
            output.AppendLine("6 1700692640");
            output.AppendLine("8 1762133312");
            output.AppendLine("9 1785403332");
            output.AppendLine("9 1812712043");
            output.AppendLine("4 1837912198");
            output.AppendLine("0 1923308283");
            output.AppendLine("8 1925648764");
            output.AppendLine("2 1951684676");
            output.AppendLine("8 2051689774");
            output.AppendLine("5 2089663653");
            output.AppendLine("7 2096109190");
            output.AppendLine("8 2100522306");
            output.AppendLine("3 2222963076");
            output.AppendLine("0 2320394874");
            output.AppendLine("4 2343014119");
            output.AppendLine("6 2347796988");
            output.AppendLine("4 2405752997");
            output.AppendLine("1 2461343674");
            output.AppendLine("8 2507700390");
            output.AppendLine("0 2563144828");
            output.AppendLine("9 2649050912");
            output.AppendLine("2 2656370100");
            output.AppendLine("6 2792825301");
            output.AppendLine("1 2831769133");
            output.AppendLine("9 2930053292");
            output.AppendLine("7 2936370273");
            output.AppendLine("3 2946336306");
            output.AppendLine("5 3033959396");
            output.AppendLine("0 3104934106");
            output.AppendLine("8 3114837717");
            output.AppendLine("4 3140480513");
            output.AppendLine("2 3205065638");
            output.AppendLine("2 3236887517");
            output.AppendLine("2 3282959311");
            output.AppendLine("0 3306478249");
            output.AppendLine("3 3363648528");
            output.AppendLine("8 3408035489");
            output.AppendLine("4 3439090637");
            output.AppendLine("6 3444003346");
            output.AppendLine("1 3470199591");
            output.AppendLine("5 3480453036");
            output.AppendLine("0 3490305631");
            output.AppendLine("1 3506565968");
            output.AppendLine("7 3585123350");
            output.AppendLine("0 3618937640");
            output.AppendLine("0 3638771343");
            output.AppendLine("2 3792650094");
            output.AppendLine("4 3815595208");
            output.AppendLine("5 3884584250");
            output.AppendLine("9 3911731663");
            output.AppendLine("8 3932551852");
            output.AppendLine("5 3943003928");
            output.AppendLine("5 3992901123");
            output.AppendLine("1 4042282164");
            output.AppendLine("7 4055834901");
            output.AppendLine("9 4086865161");
            output.AppendLine("0 4155619221");
            output.AppendLine("5 4181243134");
            output.AppendLine("6 4192821467");

   
            var assingment = new JobQueue();
            Assert.Equal(output.ToString(), assingment.Execute(input));
        }
        
        [Theory, MemberData("GetDataSet")]
        public void TestDataSet(DataSource input, string output)
        {
            var assignment = new JobQueue();
            Assert.Equal(output, assignment.Execute(input));
        }

        public static IEnumerable<object[]> GetDataSet
        {
            get
            {
                var data = new DataSet("Assignments/Week3/Resources/job_queue/tests");
                return data.Objects;
            }
        }
    }
}