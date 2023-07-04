using TechTalk.SpecFlow; 
using SquareEquationLib; 
using Xunit; 

[Binding] 
public class Steps { 

    private double a, b, c; 
    private double[] result = {}; 

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity3(double p0, double p1) { 
    this.a = p0; 
    this.b = p1; 
    this.c = Double.PositiveInfinity; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity3(double p0, double p1) { 
    this.a = p0; 
    this.b = p1; 
    this.c = Double.NegativeInfinity; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиNaN1(double p0, double p1) 
    { 
    this.a = double.NaN; 
    this.b = p0; 
    this.c = p1; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity1(double p0, double p1) 
    { 
    this.a = double.NegativeInfinity; 
    this.b = p0; 
    this.c = p1; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиNaN3(double p0, double p1) 
    { 
    this.a = p0; 
    this.b = p1; 
    this.c = double.NaN; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity2(double p0, double p1) 
    { 
    this.a = p0; 
    this.b = double.PositiveInfinity; 
    this.c = p1; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_NegativeInfinity2(double p0, double p1) 
    { 
    this.a = p0; 
    this.b = double.NegativeInfinity; 
    this.c = p1; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентами(double p0, double p1, double p2) 
    { 
    this.a = p0; 
    this.b = p1; 
    this.c = p2; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиNaN2(double p0, double p1) 
    { 
    this.a = p0; 
    this.b = double.NaN; 
    this.c = p1; 
    } 

    [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")] 
    public void ДопустимКвадратноеУравнениеСКоэффициентамиDouble_PositiveInfinity1(double p0, double p1) 
    { 
    this.a = double.PositiveInfinity; 
    this.b = p0; 
    this.c = p1; 
    } 


    [When(@"вычисляются корни квадратного уравнения")] 
    public void КогдаВычисляютсяКорниКвадратногоУравнения() 
    { 
    try { 
    result = SquareEquation.Solve(this.a, this.b, this.c); 
    } catch { 
    } 
    } 

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")] 
    public void ТоКвадратноеУравнениеИмеетДваКорняКратностиОдин(double p0, double p1) 
    { 
    double[] answer = {p0, p1}; 
    Array.Sort(answer); 
    Array.Sort(result); 
    Assert.Equal(answer, result); 
    } 

    [Then(@"квадратное уравнение имеет один корень (.*) кратности два")] 
    public void ТоКвадратноеУравнениеИмеетОдинКореньКратностиДва(double p0) 
    { 
    double[] answer = {p0}; 
    Assert.Equal(answer, result); 
    } 

    [Then(@"множество корней квадратного уравнения пустое")] 
    public void ТоМножествоКорнейКвадратногоУравненияПустое() 
    { 
    double[] answer = {}; 
    Assert.Equal(answer, result); 
    } 

    [Then(@"выбрасывается исключение ArgumentException")] 
    public void ТоВыбрасываетсяИсключениеArgumentException() 
    { 
    Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(a, b, c)); 
    } 
}