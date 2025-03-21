# 使用 .NET SDK 映像構建應用程式
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN apt-get update && apt-get install -y clang zlib1g-dev
# 設置工作目錄
WORKDIR /src
# 複製 .csproj 文件並還原依賴項
COPY src/applications/YouniLab.Member.WebApi/YouniLab.Member.WebApi.csproj src/applications/YouniLab.Member.WebApi/
COPY src/modules/YouniLab.Member.Application/YouniLab.Member.Application.csproj src/modules/YouniLab.Member.Application/
COPY src/modules/YouniLab.Member.Database/YouniLab.Member.Database.csproj src/modules/YouniLab.Member.Database/
COPY src/modules/YouniLab.Member.Domain/YouniLab.Member.Domain.csproj src/modules/YouniLab.Member.Domain/
# 還原依賴項
RUN dotnet restore src/applications/YouniLab.Member.WebApi/YouniLab.Member.WebApi.csproj
# 複製源代碼
COPY src/ src/
# 執行發佈操作，指定目標平台
RUN dotnet publish src/applications/YouniLab.Member.WebApi/YouniLab.Member.WebApi.csproj -c Release -r linux-x64 --self-contained -p:PublishAot=true -o /app/publish
# 使用 ASP.NET 映像來運行應用程式
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# 複製從 build 階段產生的檔案
COPY --from=build /app/publish .
# 設定容器啟動應用程式的命令
ENTRYPOINT ["./YouniLab.Member.WebApi"]