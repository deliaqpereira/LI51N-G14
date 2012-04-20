using PI.WebGarten.Demos.FollowTV.Prog.Model;
using PI.WebGarten.Demos.FollowTV.Episodes.Model;

namespace PI.WebGarten.Demos.FollowTV
{
    static class ResolveUri
    {
        public static string ForProgram(ProgItem p)
        {
            return string.Format("/programs/{0}", p.Name);
        }

        public static string ForPrograms()
        {
            return "/programs";
        }

        public static string ForEpisode(string name, Episode td)
        {
            return string.Format("/programs/{0}/{1}", name, td.Title);
        }

        public static string ForEpisodes(string name, Episode td)
        {
            return string.Format("/programs/{0}", name);
        }
    }
}