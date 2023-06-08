# Gotrays Service 文档

## 1. 项目结构

Gotrays.Service 项目是一个基于 `.NET 7`,`MASA Framework` 的微服务项目，主要包含以下几个部分：
    -   Gotrays.Contracts：提供接口定义,不包括实现，最纯净的接口定义
    -   Gotrays.Service：微服务应用层，负责提供微服务应用，包括接口实现，数据访问，业务逻辑等，不包括接口定义，使用`EFCore`+`Sqlite` 作为数据访问层


## 2. 项目迁移

### 2.1. 迁移步骤

1.  生成迁移记录

    ```bash
    dotnet ef migrations add InitialCreate 
    ```

2.  更新数据库

    ```bash
    dotnet ef database update
    ```
    
### 2.2. 迁移注意事项

1. 注意修改`appsettings.json`中的连接字符串，使用`Sqlite`作为数据库，连接字符串如下：

    ```json
    {
       "ConnectionStrings": {
            "Default": "Data Source=gotrays.db"
        }
    }  
    ```
