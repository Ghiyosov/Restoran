create table Customers
(
    CustomerId serial primary key,
    Name varchar(150),
    PhoneNumber varchar(20)
);

create table Tables
(
    TableId serial primary key,
    TableNumber varchar(20),
    IsOccupied varchar(75)
);

create table MenuItems
(
    MenuItemId serial primary key,
    Name varchar(150),
    Price decimal,
    Category varchar(150)
);

create table Orders
(
    OrderId serial primary key,
    CustomerId int references Customers(CustomerId) on delete cascade ,
    TableId int references Tables(TableId) on delete cascade,
    Status varchar(150)
);

create table OrderItems
(
    OrderItemId serial primary key,
    OrderId int references Orders(OrderId) on delete cascade,
    MenuItemId int references MenuItems(MenuItemId) on delete cascade
);