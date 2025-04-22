<!-- <template>
    <div>
      <h2>Realizar Apuesta</h2>
      <input v-model.number="usuarioId" placeholder="ID de usuario" type="number" />
      <input v-model.number="numeroApostado" placeholder="Número apostado (0-36)" type="number" />
      <input v-model.number="cantidadApostada" placeholder="Cantidad apostada" type="number" />
      <button @click="apostar">Apostar</button>
      <p v-if="resultado">{{ resultado }}</p>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        usuarioId: null,
        numeroApostado: null,
        cantidadApostada: null,
        resultado: ''
      };
    },
    methods: {
      async apostar() {
        try {
          const response = await fetch('http://localhost:5107/api/apuestas/apostar', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({
              usuarioId: this.usuarioId,
              numeroApostado: this.numeroApostado,
              cantidadApostada: this.cantidadApostada
            })
          });
          const data = await response.json();
          if (!response.ok) {
            this.resultado = data.mensaje || 'Error al realizar la apuesta.';
            return;
          }
          this.resultado = `Número ganador: ${data.numeroGanador}. ${data.mensaje} Ganancia: ${data.ganancia}`;
        } catch (error) {
          this.resultado = 'Error de conexión con el servidor.';
        }
      }
    }
  };
  </script> -->
  