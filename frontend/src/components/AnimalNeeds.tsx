import React from "react";
import { INeed } from "../interfaces/Interfaces";


type AnimalNeedsProps = {
    list: INeed[]
}
export const AnimalNeeds: React.FC<AnimalNeedsProps> = ({ list }) => {

    return (
        <ul className="collapsible">
            {list.map(need => {
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