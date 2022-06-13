# Ddd BuberDinner
REST API Following CLEAN ARCHITECTURE &amp; DDD Tutorial Using .NET 6 

This repository follows course from YouTube on channel named `Amichai Mantinband` [(link)](https://www.youtube.com/channel/UClz49zOCnzsclUJY-t62lIw). The course's name is `REST API Following CLEAN ARCHITECTURE & DDD` [(link)](https://www.youtube.com/watch?v=fhM0V2N1GpY&list=PLzYkqgWkHPKBcDIP5gzLfASkQyTdy0t4k).



For User Secrets, the commands needed are as follows.

1. Do the following only once for the BuberDinner.Api project. 

First open a command prompt at the location where the BuberDinner.Sln file is.

Then run the following command.

dotnet user-secrets init --project .\BuberDinner.Api\

This creates a UserSecretId tag in the csproj file which looks as follows.

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <UserSecretsId>274033a9-8c81-4d88-87d2-d545719b1148</UserSecretsId>
  </PropertyGroup>

After this, you can push the changes to source control. 

2. The other developers then now can pull and run the following command to create a setting which is a secret.

dotnet user-secrets set --project .\BuberDinner.Api\ "JwtSettings:Secret":"super-secret-key-from-user-secrets"

3. To list down the secrets, you can run the following.

dotnet user-secrets list --project .\BuberDinner.Api\ 


For debugging using Visual Studio Code, do the following.

1. Open a command prompt at the location where the BuberDinner.Sln file is present.
2. Next in vs code side navigation bar, click the debug icon(a triangle with a bug on it).
3. 