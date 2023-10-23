1. Ce este un viewport? 
Un viewport reprezintă o regiune dreptunghiulară a ecranului sau a ferestrei de 
desen în care este randat conținutul grafic. 
2. Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii 
OpenGL? 
Frames per second (FPS) reprezintă numărul de cadre (imagini) desenate pe ecran în 
fiecare secundă. În contextul OpenGL, FPS măsoară cât de eficient este aplicația. 
3. Când este rulată metoda OnUpdateFrame()? 
Metoda OnUpdateFrame() este apelată la începutul fiecărui frame (cadru) și este 
utilizată pentru a actualiza starea jocului sau a scenei 3D, precum mișcarea obiectelor sau 
simularea fizicii. Este apelată înainte de randarea frame-ului curent. 
4. Ce este modul imediat de randare? 
Modul imediat de randare (immediate mode rendering) se referă la o abordare mai 
veche și mai simplificată de randare în OpenGL, în care fiecare comandă de desenare era 
imediat executată. 
5. Care este ultima versiune de OpenGL care acceptă modul imediat? 
Ultima versiune a OpenGL care suportă modul imediat este OpenGL 2.1. 
6. Când este rulată metoda OnRenderFrame()? 
Metoda OnRenderFrame() este apelată după ce metoda OnUpdateFrame() a fost 
rulată pentru a desena frame-ul curent. 
7. De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată? 
Metoda OnResize() trebuie să fie executată cel puțin o dată pentru a inițializa corect 
parametrii de vizualizare OpenGL, precum Viewport și matricea de proiecție. Aceasta 
stabilește dimensiunile zonei de afișare și asigură că randarea este efectuată corect în 
funcție de dimensiunile ferestrei. 
8. Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul 
de valori pentru aceștia? 
Metoda CreatePerspectiveFieldOfView() este utilizată pentru a crea o matrice de 
proiecție perspectivă. Parametrii sunt: 
- fieldOfViewY: Acesta reprezintă unghiul vertical de câmp de vedere în radiani. De 
obicei, se utilizează valori între 0.1 și 3.14 radiani. 
- aspectRatio: Acesta reprezintă raportul dintre lățimea și înălțimea ferestrei de desen 
sau a viewport-ului. 
- zNear și zFar: Acești parametri reprezintă distanța la planul apropiat și respectiv la 
planul depărtat în spațiul de adâncime (depth space) și ar trebui să fie valori 
pozitive.
