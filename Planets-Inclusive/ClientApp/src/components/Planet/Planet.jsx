const Planet = (props) => {
  const { name, diameter, mass, distanceFromSun, pictureURL } = props;
  return (
    <div className="position-relative">
      <img src={pictureURL} className="img-fluid" />
      <div
        className="position-absolute bottom-0 p-3 w-100 text-white d-flex align-items-center"
        style={{ background: `rgba(0,0,0,.3)`, gap: '1rem' }}
      >
        <h4>{name}</h4>
        <div>Diameter: {diameter.toPrecision(5)} (Km)</div>
        <div>Mass: {mass.toPrecision(4)} (Kg)</div>
        <div>Distance from Earth: {distanceFromSun} (in light year)</div>
      </div>
    </div>
  );
};

export default Planet;