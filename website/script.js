const bubbleContainer = document.querySelector(".bubble-container")

function generateRandomInteger(min, max) {
  return Math.floor(min + Math.random() * (max - min + 1))
}

const bubbles = [
  { name: "Docker", img: "img/docker.png" },
  { name: "Kubernetes", img: "img/kubernetes.svg" },
  { name: "Terraform", img: "img/terraform.png" },
  { name: "Python", img: "img/python.png" },
  { name: "Linux", img: "img/linux.png" },
  { name: "Azure", img: "img/azure.png" },
  { name: "AWS", img: "img/aws.png" },
  { name: "Java", img: "img/java.svg" },
  { name: ".Net", img: "img/dotnet.png" },
  { name: "C#", img: "img/csharp.png" },
  { name: "Jenkins", img: "img/jenkins.png" },
  { name: "Helm", img: "img/helm.svg" },
  { name: "Gitlab", img: "img/gitlab.png" },
  { name: "Github", img: "img/github.png" },
  { name: "Flux CD", img: "img/fluxcd.png" },
  { name: "Prometheus", img: "img/prometheus.png" },
  { name: "Grafana", img: "img/grafana.png" },
  { name: "Azure Pipelines", img: "img/azure-pipelines.png" },
]



const bubbleRadius = 360
const bubbleSize = 100
const numBubbles = bubbles.length
let bubblesHtml = ""
for (let i = 0; i < numBubbles; i++) {
  bubble = bubbles[i]
  const angle = (i * 2 * Math.PI) / numBubbles
  const x = Math.cos(angle) * bubbleRadius
  const y = Math.sin(angle) * bubbleRadius

  const bubbleEl = document.createElement("div")
  bubbleEl.classList.add("bubble")
  bubbleEl.style.width = `${bubbleSize}px`
  bubbleEl.style.height = `${bubbleSize}px`
  bubbleEl.style.left = `calc(50% + ${x - bubbleSize / 2}px)`
  bubbleEl.style.top = `calc(50% + ${y - bubbleSize / 2}px)`
  bubbleEl.innerHTML = `<img src="${bubble.img}"/>`
  bubbleEl.style.animationDelay = `${i * Math.random()}s`
  bubbleContainer.appendChild(bubbleEl)
}
