USE MyDatabase;
GO

INSERT INTO Themes (Name, Description)
VALUES 
('Chaos', 'Represents disorder and unpredictability'),
('Order', 'Symbolizes structure and control'),
('Unity', 'Emphasizes togetherness and harmony'),
('Division', 'Highlights separation and contrast');

GO

INSERT INTO SeedIdeas (ThemeId, ImagePath, Description)
VALUES
(1, '/images/chaos1.jpg', 'Abstract fractal explosion'),
(2, '/images/order1.jpg', 'Perfect geometric shapes'),
(3, '/images/unity1.jpg', 'Hands joined together'),
(4, '/images/division1.jpg', 'Fractured mirror');
GO
