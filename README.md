# QuickCar Base App

Copyright © 2021 hprOne

Projekt semestralny z przedmiotu Programowanie Obiektowe.
Programowane w języku C# przy użyciu Visual Studio 2019.

Aplikacja służy do organizacji samochodów w wypożyczalni samochodowej
QuickCar. Każdy samochód może być albo w serwisie, albo wynajęty przez
klienta. Wszelkie informacje są wyświetlane w informacjach o poszczególnym
pojeździe.

Program zawiera bazę danych SQL z czterema tabelami (relacyjnie powiązane)
oraz główną aplikację operującą na w/w bazie danych.
Aplikacja posiada cztery osobne formularze - pierwsze okno zezwala na 
kontynuację ładowania programu, lub jego zakończenia. Drugi formularz
(MainWindow) to główna część aplikacji. Dodatkowo, każdy zaznaczony pojazd możemy
usunąć przy pomocy przycisku "Usuń samochód...". Możemy również przy użyciu tej
aplikacji dodać samochód przy pomocy analogicznego przycisku.

Zalecenie autora:

- Daty wynajmu oraz serwisu należy wpisywać w formacie "dd-MM-yyyy" - w przeciwnym wypadku
aplikacja zgłosi wyjątek!
