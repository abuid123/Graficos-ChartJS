const url = "https://localhost:7120/stock";
const ctx = document.getElementById('myChart').getContext('2d');

fetch(url).then(res => res.json())
.then(data=> {
    const beers = data.map(data=>data.name);
    const quantity = data.map(data=>data.quantity);
    const colors = data.map(x=>{
        return `rgba(
        ${getRandomColor(255,0)},
        ${getRandomColor(255,0)},
        ${getRandomColor(255,0)},0.5)`
    });

    dibujarTabla(beers,quantity,colors);
});

function getRandomColor(max, min){
    return Math.random() * (max - min) + min;
}

function dibujarTabla(beers,quantity,colors){
    const myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: beers,
            datasets: [{
                label: 'Cervezas',
                data: quantity,
                backgroundColor: colors,
                borderColor: colors,
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}