function formatName(touhou) {
    return touhou.firstName + ' ' + touhou.lastName;
}

const touhou = {
    firstName: 'Reimu',
    lastName: 'Hakurei',
};

function tick() {
    const element = (
        <div>
        <h1>Hello,{touhou.firstName}</h1>
        <h2>son las {new Date().toLocaleTimeString()}.</h2>
        </div>
    );
    ReactDOM.render(element, document.getElementById('root'));
}

setInterval(tick, 1000);
