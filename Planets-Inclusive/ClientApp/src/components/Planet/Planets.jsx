import React, { useState } from "react";
import { useQuery } from "react-query";
import { fetchPlanetByName, fetchPlanetNames } from "../../Api/planetApi";
import Planet from "./Planet";
import Loading from "../common/loading";
const Planets = (props) => {
  const [selectedPlanet, setSelectedPlanet] = useState();

  const { data: planets, isFetched } = useQuery(["planets"], fetchPlanetNames);
  const {
    data: planetData,
    isPreviousData,
    isLoading,
  } = useQuery(
    ["planet", selectedPlanet],
    () => fetchPlanetByName(selectedPlanet),
    {
      enabled: Boolean(selectedPlanet),
      keepPreviousData: true,
    }
    );
  
  const planetLoading = isPreviousData || isLoading;
  return (
    <div className="row">
      <div className="col-12 col-md-3">
        <div className="list-group">
          {planets &&
            planets.map((name) => (
              <button
                key={name}
                className="list-group-item list-group-item-action"
                onClick={() => setSelectedPlanet(name)}
              >
                {name}
              </button>
            ))}
        </div>
      </div>
      <div className="col-12 col-md-9">
        <div className="position-relative">
          {planetLoading && <Loading />}
          {planetData && <Planet {...planetData} />}
        </div>
      </div>
    </div>
  );
};

export default Planets;
