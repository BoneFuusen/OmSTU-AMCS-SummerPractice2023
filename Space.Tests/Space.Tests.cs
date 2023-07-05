using TechTalk.SpecFlow;
using SpaceBattle;

namespace Space.Tests;

[Binding]
public class UnitTest1
{
    double sh_x = 0, sh_y = 0, sp_x = 0, sp_y = 0; bool poss = true; double[] result; bool posit = true; bool speed = true;
    [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
    public void ДопустимКосмическийКорабльНаходитсяВТочкеПространстваСКоординатами(double p0, double p1)
    {
        this.sh_x = p0;
        this.sh_y = p1;
    }

    [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
    public void ДопустимКосмическийКорабльПоложениеВПространствеКоторогоНевозможноОпределить()
    {
        this.posit = false;
    }
    
    [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
    public void ДопустимИмеетМгновеннуюСкорость(double p0, double p1)
    {
        this.sp_x = p0;
        this.sp_y = p1;
    }

    [Given(@"скорость корабля определить невозможно")]
    public void ДопустимСкоростьКорабляОпределитьНевозможно()
    {
        this.speed = false;
    }

    [Given(@"изменить положение в пространстве космического корабля невозможно")]
    public void ДопустимИзменитьПоложениеВПространствеКосмическогоКорабляНевозможно()
    {
        this.poss = false;
    }

    [When(@"происходит прямолинейное равномерное движение без деформации")]
    public void КогдаПроисходитПрямолинейноеРавномерноеДвижениеБезДеформации()
    {
        try{
            result = Ship.Calculate(this.sh_x, this.sh_y, this.sp_x, this.sp_y, this.poss, this.posit, this.speed);
        }
        catch{}
    }
    
    [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
    public void ТоКосмическийКорабльПеремещаетсяВТочкуПространстваСКоординатами(double p0, double p1)
    {
        Assert.True(p0 == result[0] && p1 == result[1]);
    }

    [Then(@"возникает ошибка Exception")]
    public void ТоВозникаетОшибкаException()
    {
        Assert.Throws<System.ArgumentException>(() => Ship.Calculate(sh_x, sh_y, sp_x, sp_y, poss, posit, speed)); 
    }
}