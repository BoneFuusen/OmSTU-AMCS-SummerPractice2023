using SquareEquationLib;
using TechTalk.SpecFlow;

namespace BDD.Tests{

    [Binding]
    public class BDD_Tests
    {
        double a; double b; double c; double[] res;
        [Given(@"Квадратное уравнение с коэффициентами \((.*)e(.*), (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиE(int p0, int p1, int p2, int p3)
        {
            a = 1e-7; c = p2; b = p3;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиNaN_j(int p0, int p1)
        {
            a = p0; b = p1; c = double.NaN;
        }
        
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity_opa(int p0, int p1)
        {
            a = p0; b = p1; c = double.NegativeInfinity;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентами_baba(int p0, int p1, int p2)
        {
            a = p0; b = p1; c = p2;
        }

        [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиNaNlo(int p0, int p1)
        {
            a = double.NaN; b = p0; c = p1;
        }
        
        [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity_b(int p0, int p1)
        {
            a = p0; c = p1; b = double.PositiveInfinity;
        }

        [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity_a(int p0, int p1)
        {
            a = double.PositiveInfinity; b = p0; c = p1;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиNaNi(int p0, int p1)
        {
            a = p0; b = double.NaN; c = p1;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity_boba(int p0, int p1)
        {
            a = p0; b = double.NegativeInfinity; c = p1;
        }

        [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity_biba(int p0, int p1)
        {
            a = double.NegativeInfinity; b = p0; c = p1;
        }

        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity_gfg(int p0, int p1)
        {
            a = p0; b = p1; c = double.PositiveInfinity;
        }
        
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентами_aaa(int p0, int p1, int p2)
        {
            a = p0; b = p1; c = p2;
        }

        
        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void ДопустимКвадратноеУравнениеСКоэффициентами_popa(int p0, int p1, int p2)
        {
            a = p0; b = p1; c = p2;
        }
        
        [When(@"вычисляются корни квадратного уравнения")]
        public void КогдаВычисляютсяКорниКвадратногоУравнения()
        {
            try{
            res = SquareEquation.Solve(a, b, c);
            } catch{}
        }
        
        [Then(@"выбрасывается исключение ArgumentException")]
        public void ТоВыбрасываетсяИсключениеArgumentException()
        {
            Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(a, b, c));
        }

        [Then(@"множество корней квадратного уравнения пустое")]
        public void ТоМножествоКорнейКвадратногоУравненияПустое()
        {
            Assert.True(res == Array.Empty<double>());
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
        public void ТоКвадратноеУравнениеИмеетОдинКореньКратностиДва(int p0)
        {
            double[] answer = {p0}; 
            Array.Sort(answer); 
            Array.Sort(res); 
            Assert.Equal(answer, res);
        }

        [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
         public void ТоКвадратноеУравнениеИмеетДваКорняКратностиОдин(int p0, int p1)
         {
            double[] answer = {p0, p1}; 
            Array.Sort(answer); 
            Array.Sort(res); 
            Assert.Equal(answer, res);
         }
    }
}