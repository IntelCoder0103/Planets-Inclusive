export const fetchPlanetNames = async () => {
  var res = await fetch('/api/planet');
  return await res.json();
}

export const fetchPlanetByName = async (name) => {
  var res = await fetch(`/api/planet/${name}`);
  return await res.json();
}