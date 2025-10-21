<h1> PostgreSQL </h1>
docker run --name IngressPostgres -p 5432:5432 -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=BookStore_DB -d postgres:15.4

</br>
</br>

create table public.Book(
id serial primary key,
name varchar(100),
page_count integer
)

</br>
</br>

dotnet tool install --global dotnet-ef

</br>
</br>

dotnet ef migrations add Initial
dotnet ef migrations apply
dotnet ef database update

</br>
</br>

dotnet ef database update 20251020074534_Initial => silməkS