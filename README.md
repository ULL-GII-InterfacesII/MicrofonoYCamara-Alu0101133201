# Microfono Y Camara
### Sergio Guerra Arencibia - ULL - Interfaces Inteligentes

#### Micrófono  
Para el uso del micrófono dentro de nuestro proyecto Unity, lo primero que debemos de hacer es asginarle un componente "Audio Source" a un objeto vacío o a la cámara principal (dado que no tenemos ningún gameObject de micrófono). Yo he optado por esta segunda opción.  

Posteriormente creamos sobre este objeto un script desde el cual manipularemos el componente recién mencionado. 
En este script vamos a comprobar gracias al método update si una tecla (en mi caso en espacio) ha sido pulsada. Si es así, comprobamos si estamos en un estado de grabación o no. En el caso de que no estemos grabando, comenzamos a grabar con el micrófono. En cambio, si estábamos grabando terminamos la grabación y la reproducimos.   

La instrucción principal y la que más explicación necesita es la de inicio de grabación, que es la siguiente:  

```c#
   audioSource.clip = Microphone.Start("", false, 15, 48000);
```  
Este método recibe cuatro parámetros. El primero de ellos es el micrófono que se usará en la grabación, al poner la cadena vacía escoge el micrófono asignado por defecto. El segundo es si la grabación se hará ciclica, opción que hemos desactivado. El tercero es la duración de la grabación y el último es la frecuencia con la que se trabajará que en mi caso concreto es 48000.  

El script queda de la siguiente forma:  
```c#
  void Update()
    {
      if (Input.GetKeyDown("space")) {
        if (!Microphone.IsRecording(""))
          audioSource.clip = Microphone.Start("", false, 15, 48000);
        else {
          Microphone.End("");
          audioSource.Play();
        }
      }
    }
```  


#### Cámara
