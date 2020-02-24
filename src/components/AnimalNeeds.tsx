import React from "react";
import { IAnimalNeed } from "../interfaces/Interfaces";


type AnimalNeedsProps = {
    needs: IAnimalNeed[]
}
export const AnimalNeeds: React.FC<AnimalNeedsProps> = ({ needs }) => {

    return (
        <ul className="collapsible">
            {needs.map(need => {
                return (
                    <li id={need.id.toString()}>
                        <div className="collapsible-header">
                            <i className="material-icons">local_hospital</i>
                            {need.capture}
      <span className="badge">{need.count}</span></div>
                <div className="collapsible-body"><p>{need.description}</p></div>
                    </li>
                )
            })}
        </ul>
    )
}