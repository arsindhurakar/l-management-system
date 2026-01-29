# =========================
# Stage 1: Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1️⃣ Copy the .csproj files of each project and restore the dependencies.
COPY ["LManagement.API/LManagement.API.csproj", "LManagement.API/"]
COPY ["LManagement.Application/LManagement.Application.csproj", "LManagement.Application/"]
COPY ["LManagement.Domain/LManagement.Domain.csproj", "LManagement.Domain/"]
COPY ["LManagement.Infrastructure/LManagement.Infrastructure.csproj", "LManagement.Infrastructure/"]
COPY ["LManagement.Shared/LManagement.Shared.csproj", "LManagement.Shared/"]

RUN dotnet restore "LManagement.API/LManagement.API.csproj"

# 2️⃣ Copy everything else
COPY . .

# =========================
# Stage 2: Development (Hot Reload)
# =========================
# For dev, we will run dotnet watch in this stage to enable hot reload
FROM build AS development

# Expose the port for the API (default is 80)
EXPOSE 80

# 3️⃣ Use dotnet watch to run the app so it can reload on file changes
CMD ["dotnet", "watch", "run", "--project", "LManagement.API/LManagement.API.csproj"]
