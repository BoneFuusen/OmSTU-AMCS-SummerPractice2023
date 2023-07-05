using TechTalk.SpecFlow;
using SpaceBattle;
using Xunit.Sdk;

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

    //------------------------------//
    double fuel = 0; double cost = 0; double result1 = 0;

    [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
    public void ДопустимКосмическийКорабльИмеетТопливоВОбъемеЕд(int p0)
    {
        this.fuel = p0;
    }
    
    [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
    public void ДопустимИмеетСкоростьРасходаТопливаПриДвиженииЕд(int p0)
    {
        this.cost = p0;
    }

    [When(@"происходит прямолинейное равномерное движение")]
    public void КогдаПроисходитПрямолинейноеРавномерноеДвижение(){
        try{
            result1 = Ship_fuel.FuelCalc(fuel, cost);
        }
        catch{}
    }

    [Then(@"новый объем топлива космического корабля равен (.*) ед")]
    public void ТоНовыйОбъемТопливаКосмическогоКорабляРавенЕд(int p0)
    {
        Assert.Equal(p0, result1);
    }

    [Then(@"Возникает ошибка Exception")]
    public void тоВозникаетОшибкаException()
    {
        Assert.Throws<System.ArgumentException>(() => Ship_fuel.FuelCalc(fuel, cost)); 
    }

//------------------------------//

    double angle = 0; double angle_spd = 0; bool Angle = true; bool Angle_spd = true; bool poss1 = true; double result2;

    [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
    public void ДопустимКосмическийКорабльИмеетУголНаклонаГрадКОсиOX(int p0)
    {
        this.angle = p0;
    }

    [Given(@"космический корабль, угол наклона которого невозможно определить")]
    public void ДопустимКосмическийКорабльУголНаклонаКоторогоНевозможноОпределить()
    {
        this.Angle = false;
    }
    
    [Given(@"имеет мгновенную угловую скорость (.*) град")]
    public void ДопустимИмеетМгновеннуюУгловуюСкоростьГрад(int p0)
    {
        this.angle_spd = p0;
    }

    [Given(@"мгновенную угловую скорость невозможно определить")]
    public void ДопустимМгновеннуюУгловуюСкоростьНевозможноОпределить()
    {
        this.Angle_spd = false;
    }

    [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
    public void ДопустимНевозможноИзменитьУголдНаклонаКОсиOXКосмическогоКорабля()
    {
        this.poss1 = false;
    }
    
    [When(@"происходит вращение вокруг собственной оси")]
    public void КогдаПроисходитВращениеВокругСобственнойОси()
    {
        try{
            this.result2 = Ship_angle.AngleCalc(angle, angle_spd, Angle, Angle_spd, poss);
        }
        catch{}
    }
    
    [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
    public void ТоУголНаклонаКосмическогоКорабляКОсиOXСоставляетГрад(double p0)
    {
        Assert.Equal(p0, this.result2);
    }

    [Then(@"возникает ошибка Exceptionn")]
    public void тоВозникаетОшибкаExceptionn()
    {
        Assert.Throws<System.ArgumentException>(() => Ship_angle.AngleCalc(angle, angle_spd, Angle, Angle_spd, poss1)); 
    }
}