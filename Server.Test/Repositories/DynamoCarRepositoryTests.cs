using Xunit;
using System;
using HogeBlazor.Server.Repositories;
using HogeBlazor.Shared.Models.Db;
using static HogeBlazor.Server.Repositories.DynamoCarRepository;
using HogeBlazor.Shared.Models.Dto;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

namespace HogeBlazor.Server.Test.Repositories;

[Collection("ControllerCollection")]
public class DynamoCarRepositoryTests
{
    // public CarRepository Repository;
    public DynamoCarRepositoryTests()
    {
        //     // テスト用設定ファイルの読み込み
        //     IConfiguration config = new ConfigurationBuilder()
        //         .AddJsonFile("appsettings.json")
        //         .AddEnvironmentVariables()
        //         .Build();

        //     string npgsqlConnString = config.GetConnectionString("PostgresDatabase");
        //     var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        //     optionsBuilder.UseNpgsql(connectionString: npgsqlConnString);
        //     optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();   // 詳細ログの有効化
        //     var Db = new AppDbContext(optionsBuilder.Options);
        //     Repository = new CarRepository(config, Db);
    }

    private async Task prepareTableAsync()
    {
        DynamoCarRepository repo = new DynamoCarRepository();
        try
        {
            await repo.DeleteTableAsync();
        }
        catch (ResourceNotFoundException)
        {
            // テーブルが存在しない場合は無視
        }
        await repo.CreateTableAsync();
        await repo.PutAsync(cx5Factory());
    }

    private CarDto cx5Factory()
    {
        return new CarDto("car_1")
        {
            MakerName = "マツダ",
            ModelName = "CX-5",
            Url = "https://www.mazda.co.jp/cars/cx-5/",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/85/2017_Mazda_CX-5_%28KF%29_Maxx_2WD_wagon_%282018-11-02%29_01.jpg",
            // 基本情報
            BodyType = BodyType.SUV,
            DriveSystem = DriveSystem.AWD,
            PowerTrain = PowerTrain.ICE,
            ModelCode = "6BA-KF5P",
            GradeName = "25S Proactive",
            Price = 3140500,
            ModelChange = new ModelChange
            {
                Full = "2016-12-15",
                Last = "2018-01-01"
            },
            Steering = "ラック&ピニオン式",
            Suspension = new Suspension
            {
                Front = "マクファーソンストラット式",
                Rear = "マルチリンク式"
            },
            Break = new Break
            {
                Front = "ベンチレーテッドディスク",
                Rear = "ディスク"
            },
            FuelEfficiency = new[]
            {
                "ミラーサイクルエンジン",
                "アイドリングストップ機構",
                "筒内直接噴射",
                "可変バルブタイミング",
                "気筒休止",
                "充電制御",
                "ロックアップ機構付トルクコンバーター",
                "電動パワーステアリング"
            },
            // 性能
            MinTurningRadius = 5.5f,
            Fcr = new Fcr
            {
                Wltc = 13.0f,
                WltcL = 10.2f,
                WltcM = 13.4f,
                WltcH = 14.7f,
                // WltcExH = xxx,
                Jc08 = 14.2f,
            },
            Ecr = new Ecr
            {
                // Wltc = xxx,
                // WltcL = xxx,
                // WltcM = xxx,
                // WltcH = xxx,
                // WltcExH = xxx,
                // MpcWltc = xxx,
                // Jc08 = xxx,
                // MpcJc08 = xxx,
            },
            // エンジン
            Engine = new Shared.Models.Dto.Engine
            {
                Code = "PY-RPS",
                Type = "水冷直列4気筒DOHC16バルブ",
                CylinderLayout = CylinderLayout.I,
                ValveSystem = ValveSystem.DOHC,
                FuelSystem = "DI",
                FuelType = FuelType.REGULAR,
                CylinderNum = 4,
                MaxOutput = 138f,
                MaxOutputRpm = new MaxOutputRpm
                {
                    Lower = 6000,
                    Upper = 6000,
                },
                MaxTorque = 250f,
                MaxTorqueRpm = new MaxTorqueRpm
                {
                    Lower = 4000,
                    Upper = 4000,
                },
                FuelTankCap = 58,
                Displacement = 2.488f,
                Bore = 89.0f,
                Stroke = 100.0f,
                CompressionRatio = 13.0f,
            },
            // モーター1
            MotorX = new Shared.Models.Dto.Motor
            {
                // Code = xxx,
                // Type = xxx,
                // Purpose = xxx,
                // RatedOutput = xxx,
                // MaxOutput = xxx,
                // MaxOutputRpm = new MaxOutputRpm { Lower = xxx, Upper = xxx },
                // MaxTorque = xxx,
                // MaxTorqueRpm = new MaxTorqueRpm { Lower = xxx, Upper = xxx },
            },
            // モーター2
            MotorY = new Shared.Models.Dto.Motor
            {
                // Code = xxx,
                // Type = xxx,
                // Purpose = xxx,
                // RatedOutput = xxx,
                // MaxOutput = xxx,
                // MaxOutputRpm = new MaxOutputRpm { Lower = xxx, Upper = xxx },
                // MaxTorque = xxx,
                // MaxTorqueRpm = new MaxTorqueRpm { Lower = xxx, Upper = xxx },
            },
            // バッテリー
            Battery = new Shared.Models.Dto.Battery
            {
                // Type = xxx,
                // Quantity = xxx,
                // Voltage = xxx,
                // Capacity = xxx,
            },
            // タイヤ
            Tire = new Shared.Models.Dto.Tire
            {
                SectionWidth = new SectionWidth
                {
                    Front = 225,
                    Rear = 225,
                },
                AspectRatio = new AspectRatio
                {
                    Front = 55,
                    Rear = 55,
                },
                WheelDiameter = new WheelDiameter
                {
                    Front = 19,
                    Rear = 19,
                },
            },
            // トランスミッション
            Transmission = new Shared.Models.Dto.Transmission
            {
                Type = TransmissionType.AT,
                GearRatio = new GearRatio
                {
                    Front = new float[] { 3.552f, 2.022f, 1.452f, 1f, 0.708f, 0.599f },
                    Rear = 3.893f,
                },
                ReductionRatio = new ReductionRatio
                {
                    Front = 4.624f,
                    Rear = 2.928f,
                },
            },
            // 外寸
            OuterBody = new OuterBody
            {
                Length = 4545,
                Width = 1840,
                Height = 1690,
                WheelBase = 2700,
                Tread = new Tread
                {
                    Front = 1595,
                    Rear = 1595,
                },
                MinRoadClearance = 210,
            },
            // 内寸
            InteriorBody = new InteriorBody
            {
                Length = 1890,
                Width = 1540,
                Height = 1265,
            },
            // その他
            OtherBody = new OtherBody
            {
                Weight = 1620,
                DoorNum = 4,
                // LuggageCap = xxx,
                RidingCap = 5,
            },
        };
    }

    private CarDto corollaFactory()
    {
        return new CarDto("car_2")
        {
            MakerName = "トヨタ",
            ModelName = "カローラツーリング",
            Url = "https://toyota.jp/corollatouring/",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8a/Toyota_COROLLA_TOURING_HYBRID_W%C3%97B_2WD_%286AA-ZWE211W-AWXSB%29_front.jpg",
            // 基本情報
            BodyType = BodyType.STATION_WAGON,
            DriveSystem = DriveSystem.AWD,
            PowerTrain = PowerTrain.StrHV,
            ModelCode = "6AA-ZWE214W-AWXNB",
            GradeName = "HYBRID G-X E-Four",
            Price = 2678500,
            ModelChange = new ModelChange
            {
                Full = "2019-09-17",
                Last = "2021-11-15",
            },
            // Steering = "xxx",
            Suspension = new Suspension
            {
                Front = "マクファーソンストラット式コイルスプリング",
                Rear = "ダブルウィッシュボーン式コイルスプリング",
            },
            Break = new Break
            {
                Front = "ベンチレーテッドディスク",
                Rear = "ディスク",
            },
            FuelEfficiency = new string[]
            {
                "ハイブリッドシステム",
                "アイドリングストップ装置",
                "可変バルブタイミング",
                "電動パワーステアリング",
                "充電制御",
                "電気式無段変速機",
            },
            // 性能
            MinTurningRadius = 5.0f,
            Fcr = new Fcr
            {
                Wltc = 26.8f,
                WltcL = 25.1f,
                WltcM = 28.1f,
                WltcH = 26.8f,
                // WltcExH
                Jc08 = 31.0f,
            },
            Ecr = new Ecr
            {
                // Wltc
                // WltcL
                // WltcM
                // WltcH
                // WltcExH
                // MpcWltc
                // Jc08
                // MpcJc08
            },
            // エンジン
            Engine = new Shared.Models.Dto.Engine
            {
                Code = "2ZR-FXE",
                Type = "直列4気筒 DOHC 16バルブ VVT-i ミラーサイクル",
                CylinderLayout = CylinderLayout.I,
                ValveSystem = ValveSystem.DOHC,
                FuelSystem = "電子制御式燃料噴射装置(EFI)",
                FuelType = FuelType.REGULAR,
                CylinderNum = 4,
                MaxOutput = 72f,
                MaxOutputRpm = new MaxOutputRpm
                {
                    Lower = 5200,
                    Upper = 5200,
                },
                MaxTorque = 142f,
                MaxTorqueRpm = new MaxTorqueRpm
                {
                    Lower = 3600,
                    Upper = 3600,
                },
                FuelTankCap = 43,
                Displacement = 1.797f,
                Bore = 80.5f,
                Stroke = 88.3f,
                // CompressionRatio = xxx,
            },
            // モーター1
            MotorX = new Shared.Models.Dto.Motor
            {
                Code = "1NM",
                Type = "交流同期電動機",
                Purpose = "動力前用",
                // RatedOutput
                MaxOutput = 53f,
                // MaxOutputRpm
                MaxTorque = 163f,
                // MaxTorqueRpm
            },
            // モーター2
            MotorY = new Shared.Models.Dto.Motor
            {
                Code = "1MM",
                Type = "交流同期電動機",
                Purpose = "動力後用",
                // RatedOutput
                MaxOutput = 5.3f,
                // MaxOutputRpm
                MaxTorque = 55f,
                // MaxTorqueRpm
            },
            // バッテリー
            Battery = new Shared.Models.Dto.Battery
            {
                Type = "ニッケル水素電池",
                // Quantity
                // Voltage
                Capacity = 6.5f,
            },
            // タイヤ
            Tire = new Shared.Models.Dto.Tire
            {
                SectionWidth = new SectionWidth
                {
                    Front = 195,
                    Rear = 195,
                },
                AspectRatio = new AspectRatio
                {
                    Front = 65,
                    Rear = 65,
                },
                WheelDiameter = new WheelDiameter
                {
                    Front = 15,
                    Rear = 15,
                }
            },
            // トランスミッション
            Transmission = new Shared.Models.Dto.Transmission
            {
                Type = TransmissionType.PG,
                // GearRatio = new GearRatio()
                // {
                //     Front = xxx
                //     // Rear = xxx,
                // },
                ReductionRatio = new ReductionRatio
                {
                    Front = 2.834f,
                    Rear = 10.487f,
                }
            },
            // 外寸
            OuterBody = new OuterBody
            {
                Length = 4495,
                Width = 1745,
                Height = 1460,
                WheelBase = 2640,
                Tread = new Tread
                {
                    Front = 1530,
                    Rear = 1540,
                },
                MinRoadClearance = 130,
            },
            // 外寸
            InteriorBody = new InteriorBody
            {
                Length = 1790,
                Width = 1510,
                Height = 1160,
            },
            // その他
            OtherBody = new OtherBody
            {
                Weight = 1410,
                DoorNum = 4,
                // LuggageCap
                RidingCap = 5,
            },
        };
    }

    private CarDto hondaEFactory()
    {
        return new CarDto("car_4")
        {
            MakerName = "ホンダ",
            ModelName = "Honda e",
            Url = "https://www.honda.co.jp/honda-e/",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9e/Honda_e_Advance_%28ZAA-ZC7%29_front.jpg",
            // 基本情報
            BodyType = BodyType.HATCHBACK,
            DriveSystem = DriveSystem.RR,
            PowerTrain = PowerTrain.BEV,
            ModelCode = "ZAA-ZC7",
            GradeName = "Honda e Advance",
            Price = 4950000,
            ModelChange = new ModelChange
            {
                Full = "2020-08-27",
                Last = "2020-08-27",
            },
            Steering = "ラック&ピニオン式",
            Suspension = new Suspension
            {
                Front = "マクファーソン式",
                Rear = "マクファーソン式",
            },
            Break = new Break
            {
                Front = "油圧式ベンチレーテッドディスク",
                Rear = "油圧式ディスク",
            },
            FuelEfficiency = new[] {
                "電動パワーステアリング",
            },
            // 性能
            MinTurningRadius = 4.3f,
            Fcr = new Fcr
            {
                // FcrWltc
                // FcrWltcL
                // FcrWltcM
                // FcrWltcH
                // FcrWltcExh
                // FcrJc08
            },
            Ecr = new Ecr
            {
                Wltc = 138f,
                WltcL = 116f,
                WltcM = 130f,
                WltcH = 149f,
                // EcrWltcExh
                MpcWltc = 259f,
                Jc08 = 135f,
                MpcJc08 = 274f,
            },
            // エンジン
            // Engine: Engine{}
            // モーター1
            MotorX = new Shared.Models.Dto.Motor
            {
                Code = "MCF5",
                Type = "交流同期電動機",
                Purpose = "動力後用",
                RatedOutput = 60f,
                MaxOutput = 113f,
                MaxOutputRpm = new MaxOutputRpm
                {
                    Lower = 3497,
                    Upper = 10000,
                },
                MaxTorque = 315f,
                MaxTorqueRpm = new MaxTorqueRpm
                {
                    Lower = 0,
                    Upper = 2000,
                },
            },
            // モーター2
            // MotorY: Motor{}
            // バッテリー
            Battery = new Shared.Models.Dto.Battery
            {
                Type = "リチウムイオン電池",
                Quantity = 193,
                Voltage = 3.7f,
                Capacity = 50.0f,
            },
            // タイヤ
            Tire = new Shared.Models.Dto.Tire
            {
                SectionWidth = new SectionWidth
                {
                    Front = 205,
                    Rear = 225,
                },
                AspectRatio = new AspectRatio
                {
                    Front = 45,
                    Rear = 45,
                },
                WheelDiameter = new WheelDiameter
                {
                    Front = 17,
                    Rear = 17,
                },
            },
            // トランスミッション
            Transmission = new Shared.Models.Dto.Transmission
            {
                // 	Type
                // 	GearRatiosFront
                // 	RatioRear
                ReductionRatio = new ReductionRatio
                {
                    Front = 9.545f,
                },
            },
            // 外寸
            OuterBody = new OuterBody
            {
                Length = 3895,
                Width = 1750,
                Height = 1510,
                WheelBase = 2530,
                Tread = new Tread
                {
                    Front = 1510,
                    Rear = 1505,
                },
                MinRoadClearance = 145,
            },
            // 内寸
            InteriorBody = new InteriorBody
            {
                Length = 1845,
                Width = 1385,
                Height = 1120,
            },
            // その他
            OtherBody = new OtherBody
            {
                Weight = 1540,
                DoorNum = 4,
                // LuggageCap
                RidingCap = 4,
            }
        };
    }

    [Fact]
    public async void CreateAndDeleteTableSuccess()
    {
        // Arrange
        DynamoCarRepository repo = new DynamoCarRepository();
        try
        {
            await repo.DeleteTableAsync();
        }
        catch (ResourceNotFoundException)
        {
            // テーブルが存在しない場合は無視
        }
        // Act
        await repo.CreateTableAsync();
        await repo.DeleteTableAsync();
    }

    [Fact]
    public async void DeleteTableAsyncFailIfTableNotExist()
    {
        // Arrange
        DynamoCarRepository repo = new DynamoCarRepository();
        try
        {
            await repo.DeleteTableAsync();
        }
        catch (ResourceNotFoundException)
        {
            // テーブルが存在しない場合は無視
        }
        // Act
        // Assert
        var actual = Assert.ThrowsAsync<ResourceNotFoundException>(async () => await repo.DeleteTableAsync());
    }

    [Fact]
    public async void DeleteAsyncSuccess()
    {
        // Arrange
        await prepareTableAsync();
        // Act
        // Assert
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.DeleteAsync("car_1");
    }

    [Fact]
    public async void DeleteAsyncFailIfNotExist()
    {
        // Arrange
        await prepareTableAsync();
        // Act
        // Assert
        DynamoCarRepository repo = new DynamoCarRepository();
        var actual = Assert.ThrowsAsync<ArgumentException>(async () => await repo.GetAsync("not_exist"));
    }

    [Fact]
    public async void PutAsyncSuccess()
    {
        // Arrange
        await prepareTableAsync();
        // Act
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(corollaFactory());
        // Assert
        var actual = await repo.GetAsync("car_2");
        Assert.Equal("トヨタ", actual.MakerName);
        Assert.Equal("カローラツーリング", actual.ModelName);
    }

    [Fact]
    public async void GetAsyncReturnsValidValue()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        var actual = await repo.GetAsync("car_1");
        // Assert
        Assert.Equal("マツダ", actual.MakerName);
        Assert.Equal("CX-5", actual.ModelName);
        Assert.Equal("https://www.mazda.co.jp/cars/cx-5/", actual.Url);
        Assert.Equal("https://upload.wikimedia.org/wikipedia/commons/8/85/2017_Mazda_CX-5_%28KF%29_Maxx_2WD_wagon_%282018-11-02%29_01.jpg", actual.ImageUrl);
        // 基本情報
        Assert.Equal(BodyType.SUV, actual.BodyType);
        Assert.Equal(DriveSystem.AWD, actual.DriveSystem);
        Assert.Equal(PowerTrain.ICE, actual.PowerTrain);
        Assert.Equal("6BA-KF5P", actual.ModelCode);
        Assert.Equal("25S Proactive", actual.GradeName);
        Assert.Equal(3140500, actual.Price);
        Assert.Equal("2016-12-15", actual.ModelChange.Full);
        Assert.Equal("2018-01-01", actual.ModelChange.Last);
        Assert.Equal("ラック&ピニオン式", actual.Steering);
        Assert.Equal("マクファーソンストラット式", actual.Suspension.Front);
        Assert.Equal("マルチリンク式", actual.Suspension.Rear);
        Assert.Equal("ベンチレーテッドディスク", actual.Break.Front);
        Assert.Equal("ディスク", actual.Break.Rear);
        Assert.Contains("ミラーサイクルエンジン", actual.FuelEfficiency);
        Assert.Contains("アイドリングストップ機構", actual.FuelEfficiency);
        Assert.Contains("筒内直接噴射", actual.FuelEfficiency);
        Assert.Contains("可変バルブタイミング", actual.FuelEfficiency);
        Assert.Contains("気筒休止", actual.FuelEfficiency);
        Assert.Contains("充電制御", actual.FuelEfficiency);
        Assert.Contains("ロックアップ機構付トルクコンバーター", actual.FuelEfficiency);
        Assert.Contains("電動パワーステアリング", actual.FuelEfficiency);
        // 性能
        Assert.Equal(5.5f, actual.MinTurningRadius);
        Assert.Equal(13.0f, actual.Fcr.Wltc);
        Assert.Equal(10.2f, actual.Fcr.WltcL);
        Assert.Equal(13.4f, actual.Fcr.WltcM);
        Assert.Equal(14.7f, actual.Fcr.WltcH);
        Assert.Null(actual.Fcr.WltcExH);
        Assert.Equal(14.2f, actual.Fcr.Jc08);
        Assert.Null(actual.Ecr.Wltc);
        Assert.Null(actual.Ecr.WltcL);
        Assert.Null(actual.Ecr.WltcM);
        Assert.Null(actual.Ecr.WltcH);
        Assert.Null(actual.Ecr.WltcExH);
        Assert.Null(actual.Ecr.MpcWltc);
        Assert.Null(actual.Ecr.Jc08);
        Assert.Null(actual.Ecr.MpcJc08);
        // エンジン
        Assert.Equal("PY-RPS", actual.Engine.Code);
        Assert.Equal("水冷直列4気筒DOHC16バルブ", actual.Engine.Type);
        Assert.Equal(CylinderLayout.I, actual.Engine.CylinderLayout);
        Assert.Equal(ValveSystem.DOHC, actual.Engine.ValveSystem);
        Assert.Equal("DI", actual.Engine.FuelSystem);
        Assert.Equal(FuelType.REGULAR, actual.Engine.FuelType);
        Assert.Equal(4, actual.Engine.CylinderNum);
        Assert.Equal(6000, actual.Engine.MaxOutputRpm.Lower);
        Assert.Equal(6000, actual.Engine.MaxOutputRpm.Upper);
        Assert.Equal(250f, actual.Engine.MaxTorque);
        Assert.Equal(4000, actual.Engine.MaxTorqueRpm.Lower);
        Assert.Equal(4000, actual.Engine.MaxTorqueRpm.Upper);
        Assert.Equal(58, actual.Engine.FuelTankCap);
        Assert.Equal(138f, actual.Engine.MaxOutput);
        Assert.Equal(2.488f, actual.Engine.Displacement);
        Assert.Equal(89.0f, actual.Engine.Bore);
        Assert.Equal(100.0f, actual.Engine.Stroke);
        Assert.Equal(13.0f, actual.Engine.CompressionRatio);
        // モーター1
        Assert.Null(actual.MotorX.Code);
        Assert.Null(actual.MotorX.Type);
        Assert.Null(actual.MotorX.Purpose);
        Assert.Null(actual.MotorX.RatedOutput);
        Assert.Null(actual.MotorX.MaxOutput);
        Assert.Null(actual.MotorX.MaxOutputRpm.Lower);
        Assert.Null(actual.MotorX.MaxOutputRpm.Upper);
        Assert.Null(actual.MotorX.MaxTorque);
        Assert.Null(actual.MotorX.MaxTorqueRpm.Lower);
        Assert.Null(actual.MotorX.MaxTorqueRpm.Upper);
        // モーター2
        Assert.Null(actual.MotorY.Code);
        Assert.Null(actual.MotorY.Type);
        Assert.Null(actual.MotorY.Purpose);
        Assert.Null(actual.MotorY.RatedOutput);
        Assert.Null(actual.MotorY.MaxOutput);
        Assert.Null(actual.MotorY.MaxOutputRpm.Lower);
        Assert.Null(actual.MotorY.MaxOutputRpm.Upper);
        Assert.Null(actual.MotorY.MaxTorque);
        Assert.Null(actual.MotorY.MaxTorqueRpm.Lower);
        Assert.Null(actual.MotorY.MaxTorqueRpm.Upper);
        // バッテリー
        Assert.Null(actual.Battery.Type);
        Assert.Null(actual.Battery.Quantity);
        Assert.Null(actual.Battery.Voltage);
        Assert.Null(actual.Battery.Capacity);
        // タイヤ
        Assert.Equal(225, actual.Tire.SectionWidth.Front);
        Assert.Equal(225, actual.Tire.SectionWidth.Rear);
        Assert.Equal(55, actual.Tire.AspectRatio.Front);
        Assert.Equal(55, actual.Tire.AspectRatio.Front);
        Assert.Equal(19, actual.Tire.WheelDiameter.Front);
        Assert.Equal(19, actual.Tire.WheelDiameter.Rear);
        // トランスミッション
        Assert.Equal(TransmissionType.AT, actual.Transmission.Type);
        Assert.Equal(new float[] { 3.552f, 2.022f, 1.452f, 1f, 0.708f, 0.599f }, actual.Transmission.GearRatio.Front);
        Assert.Equal(3.893f, actual.Transmission.GearRatio.Rear);
        Assert.Equal(4.624f, actual.Transmission.ReductionRatio.Front);
        Assert.Equal(2.928f, actual.Transmission.ReductionRatio.Rear);
        // 外寸
        Assert.Equal(4545, actual.OuterBody.Length);
        Assert.Equal(1840, actual.OuterBody.Width);
        Assert.Equal(1690, actual.OuterBody.Height);
        Assert.Equal(2700, actual.OuterBody.WheelBase);
        Assert.Equal(1595, actual.OuterBody.Tread.Front);
        Assert.Equal(1595, actual.OuterBody.Tread.Rear);
        Assert.Equal(210, actual.OuterBody.MinRoadClearance);
        // 内寸
        Assert.Equal(1890, actual.InteriorBody.Length);
        Assert.Equal(1540, actual.InteriorBody.Width);
        Assert.Equal(1265, actual.InteriorBody.Height);
        // その他
        Assert.Equal(1620, actual.OtherBody.Weight);
        Assert.Equal(4, actual.OtherBody.DoorNum);
        Assert.Null(actual.OtherBody.LuggageCap);
        Assert.Equal(5, actual.OtherBody.RidingCap);
    }

    [Fact]
    public async void GetAsyncThrowsExceptionIfNotExist()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        // Assert
        var actual = Assert.ThrowsAsync<ArgumentException>(async () =>
            await repo.GetAsync("not_exist"));
    }

    [Fact]
    public async void QueryAsyncByMakerName()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByMakerNames()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(corollaFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "トヨタ", "マツダ" });
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
        Assert.Equal("トヨタ", actual["car_2"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByPriceLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.Price.Lower = 3140500;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByPriceUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.Price.Upper = 3140500;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByPriceBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.Price.Lower = 3140500;
        q.Price.Upper = 3140501;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByPriceNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.Price.Lower = 30000000;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByPowerTrain()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.PowerTrain = PowerTrain.ICE;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByPowerTrainNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.PowerTrain = PowerTrain.StrHV;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByDriveSystem()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.DriveSystem = DriveSystem.AWD;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByDriveSystemNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.DriveSystem = DriveSystem.RR;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByBodyType()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyType = BodyType.SUV;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyTypeNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyType = BodyType.K;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByBodyLengthLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyLength.Lower = 4545;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyLengthUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyLength.Upper = 4545;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyLengthBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyLength.Lower = 4545;
        q.BodyLength.Upper = 4545;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyLengthNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyLength.Lower = 4546;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByBodyWidthLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyWidth.Lower = 1840;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyWidthUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyWidth.Upper = 1840;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyWidthBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyWidth.Lower = 1840;
        q.BodyWidth.Upper = 1840;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyWidthNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyWidth.Lower = 1841;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByBodyHeightLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyHeight.Lower = 1690;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyHeightUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyHeight.Upper = 1690;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyHeightBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyHeight.Lower = 1690;
        q.BodyHeight.Upper = 1690;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByBodyHeightNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.BodyHeight.Lower = 1691;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByWeightLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.Weight.Lower = 1620;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByWeightUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.Weight.Upper = 1620;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByWeightBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.Weight.Lower = 1620;
        q.Weight.Upper = 1620;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByWeightNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.Weight.Lower = 1621;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByDoorNumUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.DoorNum.Upper = 4;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByDoorNumLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.DoorNum.Lower = 4;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByDoorNumBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.DoorNum.Lower = 4;
        q.DoorNum.Upper = 4;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByDoorNumNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.DoorNum.Lower = 5;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByRidingCapUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.RidingCap.Upper = 5;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByRidingCapLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.RidingCap.Lower = 5;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByRidingCapBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.RidingCap.Lower = 5;
        q.RidingCap.Upper = 5;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByRidingCapNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.RidingCap.Lower = 6;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByFcrWltcUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FcrWltc.Upper = 13.0f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByFcrWltcLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FcrWltc.Lower = 13.0f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByFcrWltcBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FcrWltc.Lower = 13.0f;
        q.FcrWltc.Upper = 13.0f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByFcrWltcNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FcrWltc.Lower = 13.1f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByFcrJc08Upper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FcrJc08.Upper = 14.2f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByFcrJc08Lower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FcrJc08.Lower = 14.2f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByFcrJc08Between()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FcrJc08.Lower = 14.2f;
        q.FcrJc08.Upper = 14.2f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByFcrJc08None()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FcrJc08.Lower = 14.3f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByMpcWltcUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.MpcWltc.Upper = 259f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByMpcWltcLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.MpcWltc.Lower = 259f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByMpcWltcBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.MpcWltc.Lower = 259f;
        q.MpcWltc.Upper = 259f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByMpcWltcNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.MpcWltc.Lower = 260f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    // EcrWltc
    [Fact]
    public async void QueryAsyncByEcrWltcUpper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.EcrWltc.Upper = 138f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByEcrWltcLower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.EcrWltc.Lower = 138f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByEcrWltcBetween()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.EcrWltc.Lower = 138f;
        q.EcrWltc.Upper = 138f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByEcrWltcNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.EcrWltc.Lower = 139f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    // EcrJc08
    [Fact]
    public async void QueryAsyncByEcrJc08Upper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.EcrJc08.Upper = 135f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByEcrJc08Lower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.EcrJc08.Lower = 135f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByEcrJc08Between()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.EcrJc08.Lower = 135f;
        q.EcrJc08.Upper = 135f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByEcrJc08None()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.EcrJc08.Lower = 136f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    // MpcJc08
    [Fact]
    public async void QueryAsyncByMpcJc08Upper()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.MpcJc08.Upper = 274f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByMpcJc08Lower()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.MpcJc08.Lower = 274f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByMpcJc08Between()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.MpcJc08.Lower = 274f;
        q.MpcJc08.Upper = 274f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("ホンダ", actual["car_4"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByMpcJc08None()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(hondaEFactory());
        // Act
        CarQuery q = new CarQuery(new[] { "ホンダ" });
        q.MpcJc08.Lower = 275f;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void QueryAsyncByFuelType()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FuelType = FuelType.REGULAR;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Single(actual);
        Assert.Equal("マツダ", actual["car_1"].MakerName);
    }

    [Fact]
    public async void QueryAsyncByFuelTypeNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        CarQuery q = new CarQuery(new[] { "マツダ" });
        q.FuelType = FuelType.BIO;
        var actual = await repo.QueryAsync(q);
        // Assert
        Assert.Empty(actual);
    }

    [Fact]
    public async void GetAttributeValuesAsyncByMakerName()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(corollaFactory());
        // Act
        var actual = await repo.GetAttributeValuesAsync("MakerName");
        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Contains<string>("マツダ", actual);
        Assert.Contains<string>("トヨタ", actual);
    }

    [Fact]
    public async void GetAttributeValuesAsyncByPowerTrain()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        await repo.PutAsync(corollaFactory());
        // Act
        var actual = await repo.GetAttributeValuesAsync("PowerTrain");
        // Assert
        Assert.Equal(2, actual.Count);
        Assert.Contains<string>(PowerTrain.ICE, actual);
        Assert.Contains<string>(PowerTrain.StrHV, actual);
    }

    [Fact]
    public async void GetAttributeValuesAsyncByNone()
    {
        // Arrange
        await prepareTableAsync();
        DynamoCarRepository repo = new DynamoCarRepository();
        // Act
        var actual = await repo.GetAttributeValuesAsync("NotExist");
        // Assert
        Assert.Empty(actual);
    }
}