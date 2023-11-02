# InzynierBackend
<br /><br /><br />
<h2>Instrukcja:<h2><br />
Aby włączyć backend najpierw należy uruchomić serwer SQL: https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads (Najlepsza opcja to SQL EXPRESS) <br />
Po zainstalowaniu Serwera SQL należy również pobrać SQL Server Management Studio  https://learn.microsoft.com/pl-pl/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16<br />
Wejdz na swoj serwer SQL za pomoca Managment Studio i utworz baze danych z dowolna nazwa<br />
Wejdź w projekt backendu na Visual Studio (zwyklym, nie Visual Studio Code)<br />
Kliknij prawym przyciskiem na Projekt_inz_backend w eksploratorze rozwiazan (menu w ktorym klikasz na pliki w projekcie)<br />
Wcisnij opcje "Zarzadzaj kluczami tajnymi uzytkownika"<br />
Wklej tam ta linijke kodu:<br />
<br />
{<br />
  "ConnectionStrings:DndDatabase": "Data Source=NazwaKomputera\\SQLEXPRESS;Database=BazaDanych;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;"<br />
}<br />
<br />
Zmien w Data Source nazwe komputera na swoja oraz w Database BazaDanych na utworzona wczesniej przez ciebe nazwe bazy danych<br />
Zapisz i wyjdz z tego pliku<br />
Wejdz w zakladke na gorze ekranu "Narzedzia"<br />
Wejdz w rubryke Menadzer pakietow Nuget<br />
Wcisnij Konsola menadzera pakietow<br />
Na dole w konsoli wpisz Update-Database<br />
Odczekaj z 20 sekund na utworzenie danych (UWAGA Build succeeded. NIE ZNACZY ZE TO KONIEC, PO OK 5 SEKUNDACH DOPIERO ROZPOCZYNA SIE DZIALANIE KOMENDY)<br />
Wlacz projekt
