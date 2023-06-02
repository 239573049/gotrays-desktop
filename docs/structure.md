# 结构设计

## 结构

- src
  - Contracts
    - Gotrays.Contracts
  - Desktop
    - Gotrays.Desktop.Client
    - Gotrays.Desktop.Service
    - Gotrays.Desktop.Share
  - Service
    - Gotrays.Service



## 结构介绍

- `src\Contracts\Gotrays.Contracts`

用于提供接口定义，定义接口设计，规范模型，提供项目通用模型和接口定义。

- `src\Desktop\Gotrays.Desktop.Client`

用于托管界面服务，定义界面所需要的实现类，是客户端托管服务，基于`Photino`实现的`Blazor HyBrid`一种方式。

- `src\Desktop\Gotrays.Desktop.Service`

客户端的`Contracts`实现。主要是实现客户端的逻辑。比如客户端使用的仓存储方式是`Sqlite`，但是`Web`不太一致，在这里可以提供不同实现，以便将界面和业务隔离开来。如果需要支持不太平台只需要提供不同业务实现即可。

- `src\Desktop\Gotrays.Dekstop.Share`

实现核心界面设计，不包含业务逻辑，使用`Blazor`实现，可以跨平台，仿`discord`的界面设计模式。

- `src\Service\Gotrays.Service`

后端实现。用于提供`WebApi`服务，提供`SignalR`服务用于实时通信，以便实现`discord`的交流方式，架构设计采用`MasaFramework`提供的`DDD`+`CQRS`模板实现架构设计。





