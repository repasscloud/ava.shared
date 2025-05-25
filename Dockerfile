# Dockerfile.migrate
FROM repasscloud/dotnet-sdk-preloaded:9.0.300 AS build

# 1. copy csproj & restore to leverage layer caching
WORKDIR /app
COPY Ava.Shared/*.csproj ./Ava.Shared/
RUN --mount=type=cache,target=/root/.nuget/packages \
    dotnet restore ./Ava.Shared/Ava.Shared.csproj

# 2. copy in all your code & build
COPY Ava.Shared/. ./Ava.Shared/
WORKDIR /app/Ava.Shared
RUN dotnet restore
RUN dotnet build -c Release --no-restore

# 3. install EF tools (already in SDK image, but safe to do again)
#RUN dotnet tool install --global dotnet-ef

# 4. add PATH so that dotnet-ef is picked up
#ENV PATH="$PATH:/root/.dotnet/tools"

# NOTE: No ENTRYPOINT/CMD here—compose will override
