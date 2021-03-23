import React from "react";
import { INeed } from "../interfaces/Interfaces";

type AnimalNeedsProps = {
    list: INeed[]
}

export const AnimalNeedsList = (data: AnimalNeedsProps) => {
    var exists = data.list != null && data.list.length > 0;

    return (
        <>
            <div className="row shelter-profile_tabs_tab">
                <div className="row">
                    <h5 className="center-align orange-text">A little bit about us</h5>
                </div>
                {exists ?
                    <ul className="collapsible">
                        {data.list.map(need => {
                            return (
                                <li id={need.id.toString()}>
                                    <div className="collapsible-header">
                                        <i className="material-icons">local_hospital</i>
                                        {need.title}
                                        <span className="badge">{need.count}</span></div>
                                    <div className="collapsible-body"><p>{need.description}</p></div>
                                </li>
                            )

                        })}
                    </ul>
                    :
                    <p>Our pets don't need anything :)</p>
                }

            </div>
        </>
    )
}