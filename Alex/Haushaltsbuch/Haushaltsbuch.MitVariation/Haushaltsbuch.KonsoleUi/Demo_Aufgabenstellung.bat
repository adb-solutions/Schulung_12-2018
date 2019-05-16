@echo off
chcp 65001
del Buchungsdatenbank.data
echo "INIT"
start hb auszahlung 0 Kleidung
start hb auszahlung 20 Restaurantbesuche
start hb auszahlung 01.12.2014 120,67 Restaurantbesuche
start hb einzahlung 01.12.2014 120,67
start hb auszahlung 01.12.2014 600 Miete
start hb einzahlung 01.12.2014 600
start hb auszahlung 01.12.2014 421,67 Lebenshaltung
start hb einzahlung 01.12.2014 421,67
start hb auszahlung 01.12.2014 78,90 Kleidung
start hb einzahlung 01.12.2014 78,90

start hb auszahlung 0 Lebenshaltung
start hb einzahlung 76,44

cls
echo "Initialisierung abgeschlossen"
pause
cls
@echo on
hb auszahlung 5,99 Restaurantbesuche Schokobecher
@echo off
pause

start hb einzahlung 01.01.2015 1378,45
pause
@echo on
hb auszahlung 01.01.2015 700 Miete
@echo off
pause

start hb auszahlung 306,35 Miete
start hb auszahlung 372,12 Lebenshaltung
pause
@echo on
hb einzahlung 400
@echo off
pause

start hb auszahlung 100 Lebenshaltung
start hb auszahlung 293,65 Miete
start hb auszahlung 6,35 Kleidung
start hb auszahlung 01.01.2015 628,02 Miete
pause
@echo on
hb einzahlung 01.01.2015 400
@echo off
pause

start hb einzahlung 405,01 Kleidung
start hb auszahlung 72,55 Kleidung
start hb auszahlung 69,96 Restaurantbesuche

pause
@echo on
hb übersicht
@echo off
pause

@echo on
hb übersicht 12 2014
@echo off
echo "ENDE"
pause