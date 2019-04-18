use GuildCars

SET IDENTITY_INSERT Make ON
INSERT INTO Make(MakeID, MakeName, DateAdded)
VALUES (1, 'Honda', '03/19/2019');

SET IDENTITY_INSERT Make off


set identity_insert Model on
insert into Model(ModelID, ModelName, DateAdded, MakeID)
values (1, 'Civic', '03/19/2019', 1);

set identity_insert Model off 

set identity_insert Car on
insert into Car(CarID, Vin, ModelID, CarYear, BodyStyle, Trans, Color, Interior, Mileage, SalePrice, MSRP, CarDescription, CarType)
values (1, 'KMHDH4AE1FU260822', 1, '2001', 'Sedan', '4-Cylinder', 'Blue', 'Grey', '100,000', 3000, 4000, 'Its old', 'Used')

set identity_insert Car off


select * from Car