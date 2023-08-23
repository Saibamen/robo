Prosty program konsolowy w VB2022 pozwalający na wprowadzanie ocen uczniów szkoły podstawowej: dla uczniów w wieku 6-9 lat oceny są wprowadzone literowa A – E i przeliczane liczbowo, 
gdzie A to 6, B - 5, C-3, D-2 i E-1, a dla uczniów w wieku 10-15 lat oceny 1-6. Przy każdej ocenie, bez względu na wiek może wystąpić znak "+" lub "-", nie ważne z której strony oceny. 
Z ocen cząstkowych liczona jest maksymalna i minimalna ocena oraz średnia 
Oceny mogą być wprowadzane do pamięci (InMemory) albo do pliku (InFile)  (i to działa, w tym zakresie nie trzeba nic robić)

Dodatkowo w InMemory dorobiłem możliwość zapisu do pliku (po wprowadzeniu ocen) <-- Metoda StudentSaveInMemoryToTxt() ma się znaleźć w klasie InMemory - tego nie wiem jak zrobić,
oraz
zgodnie z sugestiami przeniosłem metodę PartialResults() (wyświetlanie ocen cząstkowych) do klasy bazowej, a też się to nie spodobało. Dla mnie ta metoda musi być zarówno dla StudentInMemory,
jak i dla StudentInFile. Tu pewnie chodzi o to, by lista "grades" w klasach InMemory i InFile pozostała listą prywatną, a nie internal.

To jest programik, na zaliczenie i brakuje mu jeszcze wielu innych rzeczy, ale nie jest to przedmiotem certyfikacji np. brak jest odczytu pliku po wprowadzeniu danych ucznia itp. 
Tej prostej aplikacji na ten moment mam nie rozszerzać.

Czyli do poprawy jest: 
1. ogarnięcie wywołania metody PartialResults() (z przeciążeniem?)
2. zapis ocen do pliku z klasu InMemory przenieść do klasy InFile.
Brakuje mi zwyczajnie praktyki
