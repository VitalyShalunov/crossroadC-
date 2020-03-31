using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormsAppCrossroad
{
    class Cross : Crossroad
    {
        public int this [int index]
        {
            get { return countcar[index]; }
            set { countcar[index] = value; }
        }

        private int countSpecCarAtTheLine1;
        public int CountSpecCarAtTheLine1
        {
            get
            {
                return countSpecCarAtTheLine1;
            }
            set
            {
                countSpecCarAtTheLine1 = value;
            }
        }
        private int[] countcar = new int[4]; //кол-во машин в определенном направлении
        protected Crossroad form = new Crossroad();
        private int i;
        int countStop1;
        int countStop2;
        int countStop3;
        int countStop4;
        private List<MemberOfTraffic> memberOfTraffics;
        private List<TrafficLight> trafficLights;
        public Cross()
        {
            countStop1 = 0; //количество остановившихся на светофоре
            countStop2 = 0;
            countStop3 = 0;
            countStop4 = 0;
            countcar[0] = countcar[1] = countcar[2] = countcar[3] = 0;
            memberOfTraffics = new List<MemberOfTraffic>();
            Random random = new Random();
            trafficLights = new List<TrafficLight>();
            for (int i = 1; i < 5; i++)
            {
                trafficLights.Add(new TrafficLight(i));
            }
           
            Paint();

           
        }
        /// <summary>
        /// Отрисовка перекрестка
        /// </summary>
        public void Paint()
        {
            Brush brush = new SolidBrush(Color.DimGray);
            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            g.FillRectangle(brush, r);
            brush.Dispose();
            brush = new SolidBrush(Color.White);
            r = new Rectangle(0, form.Height / 2 - 125, form.Width / 2 - 125, 15);
            g.FillRectangle(brush, r);
            r = new Rectangle(form.Width / 2 + 110, form.Height / 2 - 125, form.Width - form.Width / 2 - 110, 15);
            g.FillRectangle(brush, r);
            r = new Rectangle(0, this.Height / 2 + 125, this.Width / 2 - 125, 15);
            g.FillRectangle(brush, r);
            r = new Rectangle(form.Width / 2 + 110, form.Height / 2 + 125, form.Width - form.Width / 2 - 110, 15);
            g.FillRectangle(brush, r);

            r = new Rectangle(form.Width / 2 - 140, 0, 15, form.Height / 2 - 110);
            g.FillRectangle(brush, r);
            r = new Rectangle(form.Width / 2 + 110, 0, 15, form.Height / 2 - 110);
            g.FillRectangle(brush, r);
            r = new Rectangle(form.Width / 2 - 140, form.Height / 2 + 125, 15, form.Height);
            g.FillRectangle(brush, r);
            r = new Rectangle(form.Width / 2 + 110, form.Height / 2 + 125, 15, form.Height);
            g.FillRectangle(brush, r);
            brush.Dispose();

            brush = new SolidBrush(Color.DarkGreen);
            r = new Rectangle(0, 0, form.Width / 2 - 140, form.Height / 2 - 125);
            g.FillRectangle(brush, r);
            r = new Rectangle(form.Width / 2 + 125, 0, form.Width - form.Width / 2 + 110, form.Height / 2 - 125);
            g.FillRectangle(brush, r);
            r = new Rectangle(0, form.Height / 2 + 140, form.Width / 2 - 140, form.Height / 2 - 125);
            g.FillRectangle(brush, r);
            r = new Rectangle(form.Width / 2 + 125, form.Height / 2 + 140, form.Width - form.Width / 2 + 110, form.Height / 2 - 125);
            g.FillRectangle(brush, r);
            brush.Dispose();
           
        }

        public void PaintTraffic()
        {
            for (int i = 0; i < 4; i++)
            {
                this.trafficLights[i].drawOwn();
            }
        }
        /// <summary>
        /// Дистанция до встречного спец.транспорта
        /// </summary>
        public int DistanceToSpecCar(MemberOfTraffic car)
        {
            for (int j = 0; j < memberOfTraffics.Count - 1; j++)
            {
                if (car.GetType() == memberOfTraffics[j].GetType())
                {
                    switch (car.Destination)
                    {
                        case 1:
                            if (memberOfTraffics[j].Destination == 4 && car.Y - car.Length < memberOfTraffics[j].Y)
                                return memberOfTraffics[j].Y - car.Y;
                            break;
                        case 2:
                            if (memberOfTraffics[j].Destination == 3 && car.X + car.Length > memberOfTraffics[j].X)
                                return car.X - memberOfTraffics[j].X;
                            break;
                        case 3:
                            if (memberOfTraffics[j].Destination == 2 && car.X - car.Length < memberOfTraffics[j].X)
                                return memberOfTraffics[j].X - car.X;
                            break;
                        case 4:
                            if (memberOfTraffics[j].Destination == 1 && car.Y + car.Length > memberOfTraffics[j].Y)
                                return car.Y - memberOfTraffics[j].Y;
                            break;
                        default:
                            return 0;
                    }
                }
            }
            return 2000;
        }
        /// <summary>
        /// Установление связей на начальном этапе
        /// </summary>
        private int SetLink()
        {
            for (int j = memberOfTraffics.Count - 2; j >= 0; j--) //установление связей между автомобилями
            {
                if (memberOfTraffics[memberOfTraffics.Count - 1].GetType() == typeof(SpecCar) && memberOfTraffics[j].GetType() == typeof(SpecCar))
                {
                    if (memberOfTraffics[memberOfTraffics.Count - 1].Destination == memberOfTraffics[j].Destination)
                    {
                        memberOfTraffics[memberOfTraffics.Count - 1].Next = memberOfTraffics[j];
                        if (memberOfTraffics[memberOfTraffics.Count - 1].DistanceToNext < 30)
                            return 0;
                        return 1;
                    }
                }
                else
                {
                    if (memberOfTraffics[memberOfTraffics.Count - 1].GetType() != typeof(SpecCar))
                    {
                        int prov = 1;
                        if (memberOfTraffics[j].GetType() == typeof(SpecCar))
                        {
                            SpecCar car = (SpecCar)memberOfTraffics[j];
                            if (car.AtTheLine == 1 || car.ChangeLine == 1)
                            {
                                int answer = Last(car);
                                if (answer == 1)
                                    prov = 1;
                                else
                                {
                                    prov = 0;
                                }
                            }
                            else
                            {
                                prov = 0;
                            }
                        }
                        if (prov == 1)
                        {
                            if (memberOfTraffics[memberOfTraffics.Count - 1].Destination == memberOfTraffics[j].Destination)
                            {
                                memberOfTraffics[memberOfTraffics.Count - 1].Next = memberOfTraffics[j];
                                if (memberOfTraffics[memberOfTraffics.Count - 1].DistanceToNext < 30)
                                    return 0;
                                return 1;
                            }
                        }
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// Вызов функций для запуска таймера, если началась пробка
        /// </summary>
        private void StartTimerForCheckTrafficJam(MemberOfTraffic car)
        {
            switch (car.Destination)
            {
                case 1:
                    if (this.trafficLights[0].color == 1)
                        CheckTrafficJam(1);
                    break;
                case 2:
                    if (this.trafficLights[1].color == 1)
                        CheckTrafficJam(2);
                    break;
                case 3:
                    if (this.trafficLights[2].color == 1)
                        CheckTrafficJam(3);
                    break;
                case 4:
                    if (this.trafficLights[3].color == 1)
                        CheckTrafficJam(4);
                    break;
            }
        }

        /// <summary>
        /// По истечению таймера проверка, остались ли ещё пробки
        /// </summary>
        public void TimerTrafficJam(int dir, MemberOfTraffic last)
        {
            //countStop1 = 0; countStop2 = 0; countStop3 = 0; countStop4 = 0;
            int checkLast = 0;
            MemberOfTraffic lastNow = null;
            for (int t = memberOfTraffics.Count - 1; t >= 0; t--)
            {
                if (memberOfTraffics[t].Destination == dir && memberOfTraffics[t].GetType() != typeof(SpecCar))
                {
                    switch (dir)
                    {
                        case 1:
                            if (memberOfTraffics[t].Y <= form.Height / 2 - 110)
                                countStop1++;
                            if (checkLast == 0)
                            {
                                lastNow = memberOfTraffics[t];
                                checkLast = 1;
                                countStop1 = 1;
                            }
                            break;
                        case 2:
                            if (memberOfTraffics[t].X >= form.Width / 2 + 110)
                                countStop2++;
                            if (checkLast == 0)
                            {
                                lastNow = memberOfTraffics[t];
                                checkLast = 1;
                                countStop2 = 1;
                            }
                            break;
                        case 3:
                            if (memberOfTraffics[t].X <= form.Width / 2 - 110)
                                countStop3++;
                            if (checkLast == 0)
                            {
                                lastNow = memberOfTraffics[t];
                                checkLast = 1;
                                countStop3 = 1;
                            }
                            break;
                        case 4:
                            if (memberOfTraffics[t].Y >= form.Height / 2 + 110)
                                countStop4++;
                            if (checkLast == 0)
                            {
                                lastNow = memberOfTraffics[t];
                                checkLast = 1;
                                countStop4 = 1;
                            }
                            break;
                    }
                }
            }
            switch (dir)
            {
                case 1:
                    if ((countStop1>=2) && (lastNow == last))
                    {
                        timerGame.Stop();
                        reason = 1;
                        check = 0;
                        click = 0;
                    }
                    break;
                case 2:
                    if ((countStop2 >=4) && (lastNow == last))
                    {
                        timerGame.Stop();
                        reason = 2;
                        check = 0;
                        click = 0;
                    }
                    break;
                case 3:
                    if ((countStop3 >=4) && (lastNow == last))
                    {
                        timerGame.Stop();
                        reason = 3;
                        check = 0;
                        click = 0;
                    }
                    break;
                case 4:
                    if ((countStop4 >=2) && (lastNow == last))
                    {
                        timerGame.Stop();
                        reason = 4;
                        check = 0;
                        click = 0;
                    }
                    break;
            }
        }
        //TODO: подумать над оптимизацией двух функций
        /// <summary>
        /// Проверка есть ли пробка и запуск таймера
        /// </summary>
        private void CheckTrafficJam(int direction)
        {
            int direction2 = 0;
            int check = 0;
            countStop1 = 0;
            countStop2 = 0;
            countStop3 = 0;
            countStop4 = 0;
            if (direction == 1) direction2 = 4;
            if (direction == 4) direction2 = 1;
            if (direction == 2) direction2 = 3;
            if (direction == 3) direction2 = 2;
            int[] lastObj = new int[4];
            lastObj[0] = lastObj[1] = lastObj[2] = lastObj[3] = 0;
            if (((direction == 1 || direction == 4) && trafficLights[0].color == 1) || ((direction == 2 || direction == 3) && trafficLights[1].color == 1))
            {
                for (int t = memberOfTraffics.Count - 1; t >= 0; t--)
                {
                    if (memberOfTraffics[t].GetType() != typeof(SpecCar))
                    {
                        if (memberOfTraffics[t].Destination == direction || memberOfTraffics[t].Destination == direction2)
                        {
                            switch (memberOfTraffics[t].Destination)
                            {
                                case 1:
                                    if (memberOfTraffics[t].Y <= form.Height / 2 - 110)
                                        countStop1++;
                                    if (lastObj[0] == 0)
                                    {
                                        lastObj[0]++;
                                        if (memberOfTraffics[t] != carStop1)
                                        {
                                            carStop1 = memberOfTraffics[t];
                                            check++;
                                        }
                                    }
                                    break;
                                case 2:
                                    if (memberOfTraffics[t].X >= form.Width / 2 + 110)
                                        countStop2++;
                                    if (lastObj[1] == 0)
                                    {
                                        lastObj[1]++;
                                        if (memberOfTraffics[t] != carStop2)
                                        {
                                            carStop2 = memberOfTraffics[t];
                                            check++;
                                        }
                                    }
                                    break;
                                case 3:
                                    if (memberOfTraffics[t].X <= form.Width / 2 - 110)
                                        countStop3++;
                                    if (lastObj[2] == 0)
                                    {
                                        lastObj[2]++;
                                        if (memberOfTraffics[t] != carStop3)
                                        {
                                            carStop3 = memberOfTraffics[t];
                                            check++;
                                        }
                                    }
                                    break;
                                case 4:
                                    if (memberOfTraffics[t].Y >= form.Height / 2 + 110)
                                        countStop4++;
                                    if (lastObj[3] == 0)
                                    {
                                        lastObj[3]++;
                                        if (memberOfTraffics[t] != carStop4)
                                        {
                                            carStop4 = memberOfTraffics[t];
                                            check++;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                if (check == 1)
                {
                    if (countStop1 >=2)
                    {
                        timer1.Stop();
                        timer1.Start();
                    }
                    if (countStop2 >= 4)
                    {
                        timer2.Stop();
                        timer2.Start();
                    }
                    if (countStop3 >= 4)
                    {
                        timer3.Stop();
                        timer3.Start();
                    }
                    if (countStop4 >= 2)
                    {
                        timer4.Stop();
                        timer4.Start();
                    }
                }
            }
        }

        /// <summary>
        /// Может ли ехать автомобиль
        /// </summary>
        public int SkipOrNot(int index, ref MemberOfTraffic car)
        {
            if (trafficLights[index].color == 3 || car.GetType() == typeof(SpecCar))
            {
                if (car.GetType() != typeof(SpecCar))
                    return 1;
                else
                {
                    var answer = CheckCrossSpecCar(ref car);
                    return answer;
                }
            }
            else
            {
                switch (car.Destination)
                {
                    case 1:
                        if (car.Y < form.Height / 2 - 110 && car.Y > form.Height / 2 - 130)
                        {
                            return 0;
                        }
                        else
                            return 2;
                    case 2:
                        if (car.X > form.Width / 2 + 110 && car.X < form.Width / 2 + 130)
                        {
                            return 0;
                        }
                        else
                            return 2;
                    case 3:
                        if (car.X < form.Width / 2 - 110 && car.X > form.Width / 2 - 130)
                        {
                            return 0;
                        }
                        else
                            return 2;
                    case 4:
                        if (car.Y > form.Height / 2 + 110 && car.Y < form.Height / 2 + 130)
                        {
                            return 0;
                        }
                        else
                            return 2;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// Осуществить передвижение автомобилей
        /// </summary>
        public void PerformMove()
        {
            NewCar(); //создание нового автомобиля
            for (i = 0; i < memberOfTraffics.Count; i++) //основной цикл движения 
            {
                if (memberOfTraffics[i] != null)
                {
                    memberOfTraffics[i].Ride();
                    DeleteObject();
                }
            }
            CheckCrash(); //проверка аварий
        }

        /// <summary>
        /// задать прямоугольник
        /// </summary>
        private Rectangle setRect(int des, ref MemberOfTraffic member)
        {
            Rectangle rectangle;
            switch (des) //первый автомобиль
            {
                case 1:
                    return rectangle = new Rectangle(member.X, member.Y - member.Length, member.Width, member.Length);
                case 2:
                    return rectangle = new Rectangle(member.X, member.Y, member.Length, member.Width);
                case 3:
                    return rectangle = new Rectangle(member.X - member.Length, member.Y - member.Width, member.Length, member.Width);
                case 4:
                    return rectangle = new Rectangle(member.X - member.Width, member.Y, member.Width, member.Length);
                default:
                    return rectangle = new Rectangle();
            }
        }
        /// <summary>
        /// Проверка аварии
        /// </summary>
        private void CheckCrash()
        {
            int k;
            for (k = 0; k < memberOfTraffics.Count - 1; k++) //определяем врезаются ли автомобили
            {
                Rectangle OBJ1, OBJ2; //создаем структуры-прямоугольники для вычисления, пересекаются ли они (есть ли авария)
                MemberOfTraffic obj1 = memberOfTraffics[k];
                OBJ1 = setRect(memberOfTraffics[k].Destination, ref obj1);
                {
                    for (int v = k + 1; v < memberOfTraffics.Count; v++) //ищем, с кем может пересечься
                    {
                        MemberOfTraffic obj2 = memberOfTraffics[v];
                        OBJ2 = setRect(memberOfTraffics[v].Destination, ref obj2);
                        {
                            {
                                if (!(OBJ1.Top > OBJ2.Bottom || OBJ1.Bottom < OBJ2.Top || OBJ1.Right < OBJ2.Left || OBJ1.Left > OBJ2.Right))
                                {
                                     MemberOfTraffic c = obj2.Next;
                                     reason = 5;
                                     check = 0;

                                    click = 0;
                                    //obj1.Ride();
                                    obj2.Ride();
                                    timerGame.Stop();
                                    form.Close();
                                    break;
                                }
                            }
                        }
                    }
                    if (check == 0)
                        break;
                }
            }
        }

        /// <summary>
        /// Удаление объекта
        /// </summary>
        private void DeleteObject()
        {
            using (var form = new Crossroad())
            {
                if (memberOfTraffics[i].Y - memberOfTraffics[i].Length >= form.Height + 10 || memberOfTraffics[i].X + memberOfTraffics[i].Length <= -10 || memberOfTraffics[i].X - memberOfTraffics[i].Length >= form.Width + 10 || memberOfTraffics[i].Y + memberOfTraffics[i].Length <= -10)
                {

                    int direction = memberOfTraffics[i].Destination; //направление удаляемого
                    Type typedel = memberOfTraffics[i].GetType();//тип удаляемого, важен спец.транспорт
                    countcar[memberOfTraffics[i].Destination - 1]--;
                    foreach (var car in memberOfTraffics)
                    {
                        if (memberOfTraffics[i] != car && car.Next == memberOfTraffics[i].Next)
                        {
                            car.Next = null;
                        }
                    }
                    memberOfTraffics.Remove(memberOfTraffics[i]);
                    total++;
                }
            }
        }
        /// <summary>
        /// Проверка последний ли автомобиль
        /// </summary>
        /// 
        private int Last(SpecCar spec)
        {
            int lastCoord = 0;
            int coordCar = -1;
            int check = 0;
            MemberOfTraffic last = null;
            switch (spec.Destination)
            {
                case 1:
                    lastCoord = form.Height + 110;
                    coordCar = spec.Y - spec.Length;
                    break;
                case 2:
                    lastCoord = -110;
                    coordCar = spec.X + spec.Length;
                    break;
                case 3:
                    lastCoord = form.Width + 110;
                    coordCar = spec.X - spec.Length;
                    break;
                case 4:
                    lastCoord = -110;
                    coordCar = spec.Y + spec.Length;
                    break;
            }
            foreach (var car in memberOfTraffics)
            {
                int kontr = 1;
                SpecCar car1;

                if (car is SpecCar)
                {
                    car1 = (SpecCar)car;
                    if (car1.AtTheLine != 1 || car1.ChangeLine == 1)
                    {
                        kontr = 1;
                    }
                    else
                    {
                        kontr = 0;
                    }
                }
                if (kontr == 1)
                {
                    switch (spec.Destination)
                    {
                        case 1:
                            if (car.Y - car.Length < lastCoord)
                            {
                                lastCoord = car.Y - car.Length;
                                last = car;
                                check++;
                            }
                            break;
                        case 2:
                            if (car.X + car.Length > lastCoord)
                            {
                                lastCoord = car.X + car.Length;
                                last = car;
                                check++;
                            }
                            break;
                        case 3:
                            if (car.X - car.Length < lastCoord)
                            {
                                lastCoord = car.X - car.Length;
                                last = car;
                                check++;
                            }
                            break;
                        case 4:
                            if (car.Y + car.Length > lastCoord)
                            {
                                lastCoord = car.Y + car.Length;
                                last = car;
                                check++;
                            }
                            break;
                    }
                }
            }
            if (check > 0)
            {
                switch (spec.Destination)
                {
                    case 1:
                        if (coordCar == lastCoord)
                        {
                            check = 0;
                        }
                        break;
                    case 2:
                        if (coordCar == lastCoord || last.Next == spec)
                        {
                            check = 0;
                        }
                        break;
                    case 3:
                        if (coordCar == lastCoord)
                        {
                            check = 0;
                        }
                        break;
                    case 4:
                        if (coordCar == lastCoord)
                        {
                            check = 0;
                        }
                        break;
                }
            }
            if (check == 0)
                return 1;
            else return 0;
        }

        /// <summary>
        /// Возвращение объекта, к которому надо подключиться, если машина последняя
        /// </summary>
        public MemberOfTraffic CheckLast(ref SpecCar spec)
        {
            int checkS = 0;
            int check = 0;
            for (int i = memberOfTraffics.Count - 1; i >= 0; i--)
            {
                if (memberOfTraffics[i] != spec && memberOfTraffics[i].Destination == spec.Destination)
                {
                    SpecCar checkCar;
                    int prov = 1;
                    if (memberOfTraffics[i] is SpecCar)
                    {
                        checkCar = (SpecCar)memberOfTraffics[i];
                        if (checkCar.AtTheLine == 1)
                        {
                            prov = 1;
                            checkS = 1;
                        }
                        else
                        {
                            if (checkCar.ChangeLine == 1)
                            {
                                var answer = cross.CanChangeLine(checkCar);
                                if (answer == 1)
                                {
                                    prov = 1;
                                    checkS = 1;
                                }
                                else prov = 0;
                            }
                            else prov = 0;
                        }
                    }
                    if (prov == 1)
                    {
                        switch (spec.Destination)
                        {
                            case 1:
                                if (memberOfTraffics[i].Y - memberOfTraffics[i].Length > spec.Y )
                                    if (checkS == 0)
                                    {
                                        return memberOfTraffics[i];
                                    }
                                    else
                                    {
                                        check = 1;
                                    }
                                break;
                            case 2:
                                if (memberOfTraffics[i].X + memberOfTraffics[i].Length < spec.X)
                                    if (checkS == 0)
                                    {
                                        return memberOfTraffics[i];
                                    }
                                    else
                                    {
                                        check = 1;
                                    }
                                break;
                            case 3:
                                if (memberOfTraffics[i].X - memberOfTraffics[i].Length > spec.X)
                                    if (checkS == 0)
                                    {
                                        return memberOfTraffics[i];
                                    }
                                    else
                                    {
                                        check = 1;
                                    }
                                break;
                            case 4:
                                if (memberOfTraffics[i].Y + memberOfTraffics[i].Length < spec.Y)
                                    if (checkS == 0)
                                    {
                                        return memberOfTraffics[i];
                                    }
                                    else
                                    {
                                        check = 1;
                                    }
                                break;
                        }
                        if (check == 1)
                        {
                            MemberOfTraffic last = memberOfTraffics[i] ;
                            for (int j = i -1 ; j>=0; j--)
                            {
                                if (memberOfTraffics[j].Destination == spec.Destination)
                                {
                                    switch (spec.Destination)
                                    {
                                        //case 1:
                                        //    if (memberOfTraffics[j].y - memberOfTraffics[j].Length > spec.y && memberOfTraffics[j].y < memberOfTraffics[i].y)
                                        //        last = memberOfTraffics[j];
                                        //    break;
                                        //case 2:
                                        //    if (memberOfTraffics[i].x + memberOfTraffics[i].Length < spec.x && memberOfTraffics[j].x > memberOfTraffics[i].x)
                                        //        last = memberOfTraffics[j];
                                        //    break;
                                        //case 3:
                                        //    if (memberOfTraffics[i].x - memberOfTraffics[i].Length > spec.x && memberOfTraffics[j].x < memberOfTraffics[i].x)
                                        //        last = memberOfTraffics[j];
                                        //    break;
                                        //case 4:
                                        //    if (memberOfTraffics[i].y + memberOfTraffics[i].Length < spec.y && memberOfTraffics[j].y > memberOfTraffics[i].y)
                                        //        last = memberOfTraffics[j];
                                        //    break;
                                        case 1:
                                            if (memberOfTraffics[j].Y - memberOfTraffics[j].Length > spec.Y && memberOfTraffics[j].Y <last.Y)
                                                last = memberOfTraffics[j];
                                            break;
                                        case 2:
                                            if (last.X + last.Length < spec.X && memberOfTraffics[j].X > last.X)
                                                last = memberOfTraffics[j];
                                            break;
                                        case 3:
                                            if (last.X - last.Length > spec.X && memberOfTraffics[j].X < last.X)
                                                last = memberOfTraffics[j];
                                            break;
                                        case 4:
                                            if (last.Y + last.Length < spec.Y && memberOfTraffics[j].Y > last.Y)
                                                last = memberOfTraffics[j];
                                            break;
                                    }
                                }
                            }
                            return last;
                        }
                    }

                }
            }
            return null;
        }
        /// <summary>
        /// Количество спец.транспортов
        /// </summary>
        int СountSpecCar()
        {
            int k = 0;
            foreach (var item in memberOfTraffics)
            {
                if (item is SpecCar)
                    k++;
            }
            return k;
        }
        /// <summary>
        /// Создание нового автомобиля
        /// </summary>
        private void NewCar()
        {
            int check = 1;
            var random = new Random();
            if (memberOfTraffics.Count < 12)//12
            {
                do
                {
                    if (check == 0) //если 2 транспорта пересеклись
                    {
                        memberOfTraffics.RemoveAt(memberOfTraffics.Count - 1);
                        check = 1;
                    }
                    if (random.Next(0, 20) == 1) //30
                    {
                        int k = СountSpecCar();
                        //memberOfTraffics.Add(new Bus());
                        if (random.Next(1, 5) == 1)
                        {
                            if (k < 4)
                                memberOfTraffics.Add(new SpecCar());
                            //else
                            //    memberOfTraffics.Add(new LightCar());
                        }
                        else
                        {
                            switch (random.Next(1, 4))
                            // switch (4)
                            {
                                case 1:
                                    memberOfTraffics.Add(new LightCar());
                                    break;
                                case 2:
                                    memberOfTraffics.Add(new Bus());
                                    break;
                                case 3:
                                    memberOfTraffics.Add(new Truck());
                                    break;
                            }
                        }
                        if (check != 0)
                            check = SetLink();

                        if (check == 1)
                        {
                            StartTimerForCheckTrafficJam(memberOfTraffics[memberOfTraffics.Count - 1]);
                        }

                    }

                } while (check == 0);
            }
        }
        /// <summary>
        /// Проверка, есть ли авто на перекрестке
        /// </summary>
        //public int CheckCarOnTheCross(MemberOfTraffic car)
        //{
        //    switch (car.Destination)
        //    {
        //        case 1:
        //            if (car.y - car.Length > form.Height / 2 - 110 && car.y - car.Length < form.Height / 2 + 110)
        //                return 1;
        //            else
        //                return 0;
        //        case 4:
        //            if (car.y + car.Length > form.Height / 2 - 110 && car.y + car.Length < form.Height / 2 + 110)
        //                return 1;
        //            else
        //                return 0;
        //        case 2:
        //            if (car.x + car.Length > form.Width / 2 - 110 && car.x + car.Length < form.Width / 2 + 110)
        //                return 1;
        //            else
        //                return 0;
        //        case 3:
        //            if (car.x - car.Length > form.Width / 2 - 110 && car.x - car.Length < form.Width / 2 + 110)
        //                return 1;
        //            else
        //                return 0;
        //        default:
        //            return 0;
        //    }
        //}

        /// <summary>
        /// Проверка, будет ли авария при перестроении спец.транспорта
        /// </summary>
        int CrashInChangeLine(ref MemberOfTraffic car, ref SpecCar spec, int from)
        {
            int[] correct = new int[2];
            //int wid = 5;
            if (from == 30)
            {
                correct[0] = 0;
                correct[1] = 10;
            }
            else correct[0] = correct[1] = 0; //10
            switch (car.Destination)
            {
                case 1:
                    if ((car.Y > spec.Y && car.Y - car.Length - correct[0] < spec.Y) || (car.Y + correct[1] > spec.Y - spec.Length && car.Y - car.Length < spec.Y - spec.Length))
                    {
                        return 0;
                    }
                    break;
                case 2:
                    if ((car.X < spec.X && car.X + car.Length + correct[0] > spec.X) || (car.X - correct[1] < spec.X + spec.Length && car.X + car.Length > spec.X + spec.Length))
                    {
                        return 0;
                    }
                    break;
                case 3:
                    if ((car.X > spec.X && car.X - car.Length - correct[0] < spec.X) || (car.X + correct[1] > spec.X - spec.Length && car.X - car.Length < spec.X - spec.Length))
                    {
                        return 0;
                    }
                    break;
                case 4:
                    if ((car.Y < spec.Y && car.Y + car.Length + correct[0] > spec.Y) || (car.Y - correct[1] < spec.Y + spec.Length && car.Y + car.Length > spec.Y + spec.Length))
                    {
                        return 0;
                    }
                    break;
                default:
                    return 0;
            }
            return 1;
        }

        /// <summary>
        /// Проверка, можно ли сменить полосу
        /// </summary>
        public int CanChangeLine(SpecCar spec)
        {
            foreach (var car in memberOfTraffics)
            {
                if (car != spec)
                {
                    if (car.Destination == spec.Destination)
                    {
                        MemberOfTraffic check = car;
                        var answer = CrashInChangeLine(ref check, ref spec, 0);
                        if (answer == 0)
                        {
                            return 0;
                        }
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// Проверка, есть ли по близости спец.транспорт
        /// </summary>
        public SpecCar CheckExistSpecCar(MemberOfTraffic car)
        {
            List<SpecCar> arraySpecCar = new List<SpecCar>();
            foreach (var carspec in memberOfTraffics)
            {
                if (carspec is SpecCar)
                {
                    SpecCar spec = (SpecCar)carspec;
                    arraySpecCar.Add(spec);
                }
            }

            foreach (var spec in arraySpecCar)
            {
                var answer = 0;
                if (answer == 0 && spec != car)
                {
                    if (car.Destination == spec.Destination)
                    {
                        SpecCar spec1 = spec;
                        var respinse = CrashInChangeLine(ref car, ref spec1, 30);
                        if (respinse == 0)
                        {
                            return spec;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// изменение связей между спец.транспортами, если спец.транспорт перестроился
        /// </summary>
        SpecCar FindSpecCar(int destintation, SpecCar spec)
        {
            List<SpecCar> list = new List<SpecCar>();
            foreach (var item in memberOfTraffics)
            {
                if (item is SpecCar && item.Destination == destintation)
                {
                    SpecCar car = (SpecCar)item;
                    if (car.AtTheLine == 2)//|| car.ChangeLine == 2
                        list.Add((SpecCar)item);
                }
            }
            if (list.Count > 1)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (spec == list[i] && i != 0)
                    {
                        if (i < list.Count - 1)
                            list[i + 1].Next = spec;
                        return list[i - 1];
                    }
                }
                if (i < list.Count - 1)
                    list[i + 1].Next = spec;
                return null;
            }
            else return null;

        }

        /// <summary>
        /// изменение связей между транспортами, если спец.транспорт перестроился
        /// </summary>
        public int SetLinkIfSpecCarChangeLines(ref SpecCar car, int from)
        {
            MemberOfTraffic last = null;
            var check = 0;
            if (from == 1)
            {
                for (int i = memberOfTraffics.Count - 1; i >= 0; i--)
                {
                    SpecCar spec;
                    int control = 1;
                    if (memberOfTraffics[i] is SpecCar)
                    {
                        spec = (SpecCar)memberOfTraffics[i];
                        if (spec.AtTheLine != 2 || spec.ChangeLine == 1)
                        {
                            //if (spec.Next == car)
                            control = 2;
                        }
                        else control = 0;
                    }
                    if (memberOfTraffics[i] != car && car.Destination == memberOfTraffics[i].Destination && control != 0)
                    {
                        last = memberOfTraffics[i];
                        switch (car.Destination)
                        {
                            case 1:
                                if (car.Y - car.Length >= memberOfTraffics[i].Y && (car.Y <= memberOfTraffics[i].Y + memberOfTraffics[i].DistanceToNext && memberOfTraffics[i].Next != null || memberOfTraffics[i].Next == null))
                                {
                                    check = 1;
                                }
                                break;
                            case 2:
                                if (car.X + car.Length <= memberOfTraffics[i].X && ((car.X >= memberOfTraffics[i].X - memberOfTraffics[i].DistanceToNext && memberOfTraffics[i].Next != null) || memberOfTraffics[i].Next == null))
                                {
                                    check = 1;
                                }
                                break;
                            case 3:
                                if (car.X - car.Length >= memberOfTraffics[i].X && (car.X <= memberOfTraffics[i].X + memberOfTraffics[i].DistanceToNext && memberOfTraffics[i].Next != null || memberOfTraffics[i].Next == null))
                                {
                                    check = 1;
                                }
                                break;
                            case 4:
                                if (car.Y + car.Length <= memberOfTraffics[i].Y && (car.Y >= memberOfTraffics[i].Y - memberOfTraffics[i].DistanceToNext && memberOfTraffics[i].Next != null || memberOfTraffics[i].Next == null))
                                {
                                    check = 1;
                                }
                                break;
                            default:
                                break;
                        }
                        if (check == 1)
                        {
                            for (int j = 0; j < memberOfTraffics.Count; j++)
                            {
                                if (memberOfTraffics[j].Next == car)
                                {
                                    if (memberOfTraffics[j].GetType() != typeof(SpecCar))
                                    {
                                        memberOfTraffics[j].Next = car.Next;
                                        break;
                                    }
                                    else
                                    {
                                        SpecCar car1;
                                        car1 = (SpecCar)memberOfTraffics[j];
                                        if (car1.AtTheLine == 2)
                                        {
                                            memberOfTraffics[j].Next = car.Next;
                                        }
                                    }

                                }
                            }
                            car.Next = memberOfTraffics[i].Next;
                            memberOfTraffics[i].Next = car;
                            //break;
                            return 1;
                        }
                    }
                }
                return 0;
            }
            else
            {
                for (int i = 0; i < memberOfTraffics.Count; i++)
                {
                    SpecCar spec;
                    int prov = 1;
                    if (car == memberOfTraffics[i].Next)
                    {
                        if (memberOfTraffics[i].GetType() == typeof(SpecCar))
                        {
                            spec = (SpecCar)memberOfTraffics[i];
                            if (spec.AtTheLine != 2)
                                prov = 1; //1
                            else prov = 0;
                        }
                        else
                        {
                            prov = 1;
                        }
                        if (prov == 1)
                        {
                            memberOfTraffics[i].Next = car.Next;
                            check = 1;
                            break;
                        }
                    }
                }
                car.Next = FindSpecCar(car.Destination, (SpecCar)car);
            }
            return 2;

        }
        /// <summary>
        /// вычисление расстояния до авто справа
        /// </summary>
        int СalculateDistance(ref MemberOfTraffic car, int distance, int des)
        {
            List<int> time = new List<int>();
            float timeCheck = 27;
            int speed = 9;
            int distanceCheck = 120;
            switch (car.Destination)
            {
                case 1:
                    if (car.X < form.Size.Width / 2 - Width / 2 + 5)
                    {
                        distanceCheck = 220;
                    }
                    break;
                case 2:
                    if (car.Y < form.Size.Height / 2 - Width / 2 + 5)
                    {
                        distanceCheck = 220;
                    }
                    break;
                case 3:
                    if (car.Y < form.Size.Height / 2 + Width / 2 - 5)
                    {
                        distanceCheck = 220;
                    }
                    break;
                case 4:
                    if (car.X < form.Size.Width / 2 + Width / 2 - 5)
                    {
                        distanceCheck = 220;
                    }
                    break;
            }
            foreach (var checkCar in memberOfTraffics)
            {
                if (checkCar.GetType() == typeof(SpecCar))
                {
                    if (checkCar.Destination == des)
                    {
                        if (car.SpeedNow == 0)
                            timeCheck = (distanceCheck + car.Length) / car.MaxSpeed;
                        else
                            timeCheck = (distanceCheck + car.Length) / car.SpeedNow;
                        if (checkCar.SpeedNow == 0)
                            speed = checkCar.MaxSpeed;
                        else speed = checkCar.SpeedNow;
                        switch (checkCar.Destination)
                        {
                            case 1:
                                if (checkCar.Y < form.Height / 2 + checkCar.Length)
                                    time.Add((distance - checkCar.Y) / speed);
                                break;
                            case 2:
                                if (checkCar.X > form.Width / 2 - checkCar.Length)
                                    time.Add((checkCar.X - distance) / speed);
                                break;
                            case 3:
                                if (checkCar.X < form.Width / 2 + checkCar.Length)
                                    time.Add((distance - checkCar.X) / speed);
                                break;
                            case 4:
                                if (checkCar.Y > form.Height / 2 - checkCar.Length)
                                    time.Add((checkCar.Y - distance) / speed);
                                break;
                        }

                    }
                }
            }
            timeCheck += car.Length / speed;
            if (time.Count == 1)
            {
                if (timeCheck < time[0])
                    return 1;
                else
                {
                    return 0;
                }
            }
            else
            {
                if (time.Count > 1)
                {
                    if ((time[1] - time[0] + 18 > timeCheck && timeCheck < time[0]) || (timeCheck < time[0]))
                    {
                        return 1;
                    }
                    else
                        return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// проверка пересекутся ли спец.транспорты, если да, то пропустить по правилу помехи справа
        /// </summary>
        int CheckCrossSpecCar(ref MemberOfTraffic car)
        {
            switch (car.Destination)
            {
                case 1:
                    if (car.Y < form.Height / 2 - 110 && car.Y > form.Height / 2 - 130)
                    {
                        var answer = СalculateDistance(ref car, form.Width / 2 - 100, 3);
                        if (answer == 1)
                            return 1;
                        else return 0;
                    }
                    break;
                case 2:
                    if (car.X > form.Width / 2 + 110 && car.X < form.Width / 2 + 130)
                    {
                        var answer = СalculateDistance(ref car, form.Height / 2, 1);
                        if (answer == 1)
                            return 1;
                        else return 0;
                    }
                    break;
                case 3:
                    if (car.X < form.Width / 2 - 110 && car.X > form.Width / 2 - 130)
                    {
                        var answer = СalculateDistance(ref car, form.Height / 2, 4);
                        if (answer == 1)
                            return 1;
                        else return 0;
                    }
                    break;
                case 4:
                    if (car.Y > form.Height / 2 + 110 && car.Y < form.Height / 2 + 130)
                    {
                        var answer = СalculateDistance(ref car, form.Width / 2, 2);
                        if (answer == 1)
                            return 1;
                        else return 0;
                    }
                    break;
            }
            //if (car.SpeedNow == 0)
            //    car.SpeedNow = car.MaxSpeed;
            return 2;
        }

        /// <summary>
        /// изменить свойства спец.транспорта для перемещения в полосу
        /// </summary>
        //public void ChangePropertyAtTheSpecCar()
        //{
        //    foreach (var specCar in memberOfTraffics)
        //    {
        //        if (specCar is SpecCar)
        //        {
        //            SpecCar spec = (SpecCar)specCar;
        //            {
        //                spec.ChangeLine = 1;
        //                spec.CheckSetLink = 1;
        //            }
        //        }
        //    }
        //}

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerGame
            // 
            this.timerGame.Enabled = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Size = new System.Drawing.Size(1540, 985);
            // 
            // reason
            // 
           // this.reason.Location = new System.Drawing.Point(22, 92);
            // 
            // Cross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1522, 938);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Cross";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
