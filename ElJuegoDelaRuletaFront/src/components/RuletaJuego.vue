  <!-- <template>
    <div class="flex flex-col items-center justify-center min-h-screen bg-gray-300 text-center p-4">
      <h1 class="text-4xl font-bold mb-6 text-green-700">EL JUEGO DE LA RULETA</h1>
  
      <canvas ref="rouletteCanvas" width="400" height="400" class="mb-4" />
  
      <button @click="spin" :disabled="isSpinning" class="bg-green-600 text-white px-6 py-2 rounded hover:bg-green-700 transition">
        {{ isSpinning ? "Girando..." : "Girar Ruleta" }}
      </button>
      <button @click="guardarUsuario" class="mt-4 bg-blue-600 text-white px-6 py-2 rounded hover:bg-blue-700 transition">
    Guardar Monto
  </button>
      <p v-if="result" class="mt-4 text-2xl font-bold text-gray-800">Resultado: {{ result }}</p>
    </div>
    
  </template>
  
  <script setup>
  import { ref, onMounted } from 'vue'
  
  const rouletteCanvas = ref(null)
  const isSpinning = ref(false)
  const result = ref(null)
  
  const segments = ['1', '2', '3', '4', '5', '6', '7', '8','9','10','11','12','13','14','15','16','17','18','19','20','21','22','23','24','25','26','27','28','29','30','31','32','33','34','35','36']
  const colors = ['#CF010B', '#000000', '#CF010B', '#000000', '#CF010B', '#000000', '#CF010B', '#000000','#CF010B', '#000000', '#CF010B', '#000000', '#CF010B', '#000000', '#CF010B', '#000000','#CF010B', '#000000', '#CF010B', '#000000', '#CF010B', '#000000', '#CF010B', '#000000','#CF010B', '#000000', '#CF010B', '#000000', '#CF010B', '#000000', '#CF010B', '#000000','#CF010B', '#000000', '#CF010B', '#000000']
  
  let angulo = 0
  let spinAngle = 0
  
  const drawRoulette = () => {
    //prepara el el lienzo
    const canvas = rouletteCanvas.value
    //el relleno dentro de la ruleta
    const ctx = canvas.getContext('2d')
    const radius = canvas.width /2
    const arc = (2 * Math.PI) / segments.length
  //Limpia la ruleta para que no haya multiples ruletas
    ctx.clearRect(0, 0, canvas.width, canvas.height)
  
    segments.forEach((label, i) => {
      const startAngle = angulo + i * arc
      ctx.beginPath()
      ctx.fillStyle = colors[i % colors.length]
      ctx.moveTo(radius, radius)
      ctx.arc(radius, radius, radius, startAngle, startAngle + arc, false)
      ctx.fill()
  
      // Text
      ctx.save()
      ctx.translate(radius, radius)
      ctx.rotate(startAngle + arc / 2)
      ctx.fillStyle = '#FFFFFF'
      ctx.font = '16px Arial'
      ctx.fillText(label, radius - 20, 0)
      ctx.restore()
    })
  }
  
  const spin = async () => {
    if (isSpinning.value) return
    isSpinning.value = true
    result.value = null
  
    try {
      // Llama al backend para obtener el número ganador
      const response = await fetch('http://localhost:5107/api/ControladorRuleta/girar') // o el puerto que estés usando

      const data = await response.json()
      const numeroGanador = data.resultado // asegúrate de que el backend devuelva este campo
  
      const index = segments.indexOf(numeroGanador.toString())
      if (index === -1) {
        throw new Error("Resultado inválido del backend")
      }
  
      const extraSpins = 5
      const arc = (2 * Math.PI) / segments.length
      spinAngle = (2 * Math.PI) * extraSpins + (segments.length - index) * arc
  
      let duration = 3000
      let start = null
  
      const animate = (timestamp) => {
        if (!start) start = timestamp
        const progress = timestamp - start
        const ease = (t) => 1 - Math.pow(1 - t, 3)
  
        const t = Math.min(progress / duration, 1)
        angulo = ease(t) * spinAngle
        drawRoulette()
  
        if (t < 1) {
          requestAnimationFrame(animate)
        } else {
          isSpinning.value = false
          result.value = segments[index]
        }
      }
  
      requestAnimationFrame(animate)
    } catch (error) {
      console.error("Error al girar la ruleta:", error)
      isSpinning.value = false
    }
  }
  
  onMounted(() => {
    drawRoulette()
  })

  const guardarUsuario = async () => {
  const nombre = prompt("Ingresa tu nombre:");
  const monto = prompt("Ingresa tu monto actual:");

  if (!nombre || !monto) return;

  try {
    const response = await fetch('http://localhost:5107/api/ControladorUsuarios/guardar', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ nombre, monto: parseFloat(monto) })
    });

    const data = await response.json();
    alert(data.mensaje);
  } catch (error) {
    alert("Error al guardar el usuario.");
    console.error(error);
  }
  
}

  </script>
  
  
  <style scoped>
canvas {
  border: 8px solid #333;
  border-radius: 50%;
  background-color: white;
}
</style> -->
  
  