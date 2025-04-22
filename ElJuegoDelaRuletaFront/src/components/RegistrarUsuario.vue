<!-- <template>
    <div>
      <h2>Registrar Usuario</h2>
      <input v-model="nombreUsuario" placeholder="Nombre de usuario" />
      <button @click="registrarUsuario">Registrar</button>
      <p v-if="mensaje">{{ mensaje }}</p>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        nombreUsuario: '',
        mensaje: ''
      };
    },
    methods: {
      async registrarUsuario() {
        try {
          const response = await fetch('http://localhost:5107/api/usuarios/registrar', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({ nombreUsuario: this.nombreUsuario })
          });
          if (!response.ok) {
            const errorData = await response.json();
            this.mensaje = errorData.title || 'Error al registrar el usuario.';
            return;
          }
          const data = await response.json();
          this.mensaje = `Usuario registrado con ID: ${data.id}`;
        } catch (error) {
          this.mensaje = 'Error de conexión con el servidor.';
        }
      }
    }
  };
  </script> -->